using System;
using System.Collections.Generic;
using System.Linq;

namespace Radish
{
    public class Setting
    {
        public IRequestMatcher RequestMatcher { get; set; }
        public ResponseSetting ResponseSetting { get; set; }
    }

    public class HttpHandlerSetting
    {
        protected List<Setting> _settings;

        public void Then(Action<ResponseSetting> responseAction)
        {
            var lastSetting = _settings.Last();
            if (lastSetting.ResponseSetting != null)
                throw new InvalidOperationException("Please set request matcher first!");
            lastSetting.ResponseSetting = new ResponseSetting();
            responseAction(lastSetting.ResponseSetting);
        }
    }

    public class HttpServer : HttpHandlerSetting
    {
        public HttpServer()
        {
            _settings = new List<Setting>();
        }

        public HttpHandlerSetting When(Func<RequestSetting, IRequestMatcher> requestMatcherExpression)
        {
            var setting = new Setting();
            setting.RequestMatcher = requestMatcherExpression(new RequestSetting());
            _settings.Add(setting);

            return this;
        }
    }
}