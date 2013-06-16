using Radish.Matchers;

namespace Radish
{
    public abstract class RequestMatcherSetting
    {
        protected IRequestExtractor extractor;

        public AbstractRequestMatcher Is(string expected)
        {
            return new EqualRequestMatcher(extractor, expected);
        }
    }
}