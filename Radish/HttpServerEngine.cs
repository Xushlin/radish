using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Radish.Adapters;

namespace Radish
{
    public class HttpServerEngine : IDisposable
    {
        private readonly HttpServer _setting;
        private readonly int _port;
        private readonly HttpListener _listener;
        private readonly Thread _listenerThread;
        private readonly Thread[] _workers;
        private readonly ManualResetEvent _stop, _ready;
        private readonly Queue<HttpListenerContext> _queue;

        public HttpServerEngine(HttpServer setting, int port)
            : this(setting, port, 1)
        {
        }

        public HttpServerEngine(HttpServer setting, int port, int maxThread)
        {
            _setting = setting;
            _port = port;
            _workers = new Thread[maxThread];
            _queue = new Queue<HttpListenerContext>();
            _stop = new ManualResetEvent(false);
            _ready = new ManualResetEvent(false);
            _listener = new HttpListener();
            _listenerThread = new Thread(HandleRequests);
        }

        void ProcessRequest(HttpListenerContext httpListenerContext)
        {
            IHttpContext context = new HttpListenerContextAdapter(httpListenerContext);
            _setting.Proccess(context);
        }

        public HttpServerEngine Start()
        {
            _listener.Prefixes.Add(String.Format(@"http://+:{0}/", _port));

            _listener.Start();
            _listenerThread.Start();

            for (int i = 0; i < _workers.Length; i++)
            {
                _workers[i] = new Thread(Worker);
                _workers[i].Start();
            }
            return this;
        }

        public void Dispose()
        {
            Stop();
        }

        public void Stop()
        {
            _stop.Set();
            _listenerThread.Join();
            foreach (var worker in _workers)
                worker.Join();
            _listener.Stop();
        }

        private void HandleRequests()
        {
            while (_listener.IsListening)
            {
                var context = _listener.BeginGetContext(ContextReady, null);

                if (0 == WaitHandle.WaitAny(new[] { _stop, context.AsyncWaitHandle }))
                    return;
            }
        }

        private void ContextReady(IAsyncResult ar)
        {
            try
            {
                lock (_queue)
                {
                    _queue.Enqueue(_listener.EndGetContext(ar));
                    _ready.Set();
                }
            }
            catch
            {
            }
        }

        private void Worker()
        {
            var waitHanders = new WaitHandle[] { _ready, _stop };
            while (0 == WaitHandle.WaitAny(waitHanders))
            {
                HttpListenerContext context;
                lock (_queue)
                {
                    if (_queue.Count > 0)
                        context = _queue.Dequeue();
                    else
                    {
                        _ready.Reset();
                        continue;
                    }
                }

                try
                {
                    ProcessRequest(context);
                }
                catch (Exception e) { Console.Error.WriteLine(e); }
            }
        }

    }
}