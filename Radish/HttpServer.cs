using System;

namespace Radish
{
    public class HttpServer
    {
        Func<RequestSetting, bool> _requestSetting;
        Action<ResponseSetting> _responseSetting;
        public HttpServer When(Func<RequestSetting, bool> requestSetting)
        {
            _requestSetting = requestSetting;
            return this;
        }

        public void Then(Action<ResponseSetting> responseSetting)
        {
            _responseSetting = responseSetting;
        }
    }
}