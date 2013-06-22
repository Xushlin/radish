using Radish.Matchers;

namespace Radish
{
    public abstract class RequestMatcherSetting
    {
        protected IRequestExtractor extractor;

        public RequestMatcher Is(string expected)
        {
            return new EqualRequestMatcher(extractor, expected);
        }
    }
}