using System;
using System.Collections.Generic;
using System.Linq;
using Radish.Matchers;

namespace Radish
{
    public class HttpHandler
    {
        public IRequestMatcher RequestMatcher { get; set; }
        public ResponseSetting ResponseSetting { get; set; }

        public bool Match(IHttpRequest request)
        {
            return RequestMatcher.Match((request));
        }

        public void Handle(IHttpContext context)
        {
            foreach (var responseWriter in ResponseSetting.Writers)
            {
                responseWriter.Write(context.Response);
            }
        }
    }

    public class ServerResponseSetting
    {
        protected List<HttpHandler> handlers;

        public void Response(Action<ResponseSetting> responseAction)
        {
            var lastHandler = handlers.LastOrDefault();
            if (lastHandler == null || lastHandler.ResponseSetting != null)
            {
                var handler = new HttpHandler { RequestMatcher = new AnyRequestMatcher() };
                handlers.Add(handler);
                lastHandler = handler;
            }
            lastHandler.ResponseSetting = new ResponseSetting();
            responseAction(lastHandler.ResponseSetting);
        }
    }

    public class HttpServer : ServerResponseSetting
    {
        private readonly HttpHandler _pageNotFoundHandler;

        public HttpServer()
        {
            _pageNotFoundHandler = new HttpHandler { ResponseSetting = new ResponseSetting().Status(404) };
            handlers = new List<HttpHandler>();
        }

        public ServerResponseSetting Request(Func<RequestSetting, IRequestMatcher> requestMatcherExpression)
        {
            var handler = new HttpHandler { RequestMatcher = requestMatcherExpression(new RequestSetting()) };
            handlers.Add(handler);

            return this;
        }

        internal void Proccess(IHttpContext context)
        {
            foreach (var handler in handlers)
            {
                if (handler.Match(context.Request))
                {
                    handler.Handle(context);
                    return;
                }
            }
            _pageNotFoundHandler.Handle(context);
        }
    }
}