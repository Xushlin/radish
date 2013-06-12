using Radish.Extractors;

namespace Radish
{
    public class RequestSetting : RequestMatcherSetting
    {
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