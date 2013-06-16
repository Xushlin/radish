using Radish.RequestExtractors;

namespace Radish
{
    public class RequestSetting : RequestMatcherSetting
    {
        public RequestMatcherSetting Uri
        {
            get
            {
                extractor = new UriExtractor();
                return this;
            }
        }

        public RequestMatcherSetting Method
        {
            get
            {
                extractor = new HttpMethodExtractor();
                return this;
            }
        }
    }
}