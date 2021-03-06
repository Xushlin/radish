namespace Radish
{
    public abstract class RequestMatcherSetting
    {
        protected IRequestExtractor _extractor;
        
        public AbstractRequestMatcher Is(string expected)
        {
            return new EqualRequestMatcher(_extractor, expected);
        }
    }
}