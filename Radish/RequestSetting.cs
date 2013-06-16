using Radish.Extractors;

namespace Radish
{
    public class RequestSetting : RequestMatcherSetting
    {
        public RequestMatcherSetting Uri
        {
            get
            {
                extractor = new UriRequestExtractor();
                return this;
            }
        }

        public RequestMatcherSetting Method
        {
            get
            {
                extractor = new HttpMethodRequestExtractor();
                return this;
            }
        }
    }
}