namespace Radish
{
    public class RequestSetting : RequestMatcherSetting
    {
        public RequestSetting(IHttpRequest request)
            : base(request)
        {
        }

        public RequestMatcherSetting Uri
        {
            get
            {
                _extractor = new RequestUriExtractor();
                return this;
            }
        }
    }
}