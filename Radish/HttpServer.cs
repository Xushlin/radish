using System;
using System.Collections.Generic;
using System.Linq;

namespace Radish
{
    public class Setting
    {
        public IRequestMatcher RequestMatcher { get; set; }
        public ResponseHandler ResponseHandler { get; set; }

        public bool Match(IHttpRequest request)
        {
            return RequestMatcher.Match((request));
        }

        public void Handle(IHttpContext context)
        {
            ResponseHandler.Handle(context);
        }
    }

    public class HttpHandlerSetting
    {
        protected List<Setting> _settings;

        public void Then(Action<ResponseHandler> responseAction)
        {
            var lastSetting = _settings.Last();
            if (lastSetting.ResponseHandler != null)
                throw new InvalidOperationException("Please set request matcher first!");
            lastSetting.ResponseHandler = new ResponseHandler();
            responseAction(lastSetting.ResponseHandler);
        }
    }

    public class HttpServer : HttpHandlerSetting
    {
        private readonly ResponseHandler _pageNotFoundHandler;

        public HttpServer()
        {
            _pageNotFoundHandler = new ResponseHandler().Status(404);
            _settings = new List<Setting>();
        }

        public HttpHandlerSetting When(Func<RequestSetting, IRequestMatcher> requestMatcherExpression)
        {
            var setting = new Setting();
            setting.RequestMatcher = requestMatcherExpression(new RequestSetting());
            _settings.Add(setting);

            return this;
        }

        internal void Proccess(IHttpContext context)
        {
            foreach (var setting in _settings)
            {
                if (setting.Match(context.Request))
                {
                    setting.Handle(context);
                    context.Response.OutputStream.Close();
                    return;
                }
            }

        }
    }
}