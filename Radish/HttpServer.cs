using System;
using System.Collections.Generic;
using System.Linq;

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

    public class HttpHandlerSetting
    {
        protected List<HttpHandler> _handlers;

        public void Then(Action<ResponseSetting> responseAction)
        {
            var lastHandler = _handlers.Last();
            if (lastHandler.ResponseSetting != null)
                throw new InvalidOperationException("Please set request matcher first!");
            lastHandler.ResponseSetting = new ResponseSetting();
            responseAction(lastHandler.ResponseSetting);
        }
    }

    public class HttpServer : HttpHandlerSetting
    {
        private readonly HttpHandler _pageNotFoundHandler;

        public HttpServer()
        {
            _pageNotFoundHandler = new HttpHandler { ResponseSetting = new ResponseSetting().Status(404) };
            _handlers = new List<HttpHandler>();
        }

        public HttpHandlerSetting When(Func<RequestSetting, IRequestMatcher> requestMatcherExpression)
        {
            var handler = new HttpHandler();
            handler.RequestMatcher = requestMatcherExpression(new RequestSetting());
            _handlers.Add(handler);

            return this;
        }

        internal void Proccess(IHttpContext context)
        {
            foreach (var setting in _handlers)
            {
                if (setting.Match(context.Request))
                {
                    setting.Handle(context);
                    context.Response.OutputStream.Close();
                    return;
                }
            }
            _pageNotFoundHandler.Handle(context);
        }
    }
}