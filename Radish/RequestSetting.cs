using Radish.Extractors;

namespace Radish
{
    public class RequestSetting : RequestMatcherSetting
    {
        public RequestMatcherSetting Uri
        {
            get
            {
                _extractor = new UriRequestExtractor();
                return this;
            }
        }

        public RequestMatcherSetting Method
        {
            get
            {
                _extractor = new HttpMethodRequestExtractor();
                return this;
            }
        }
    }
}