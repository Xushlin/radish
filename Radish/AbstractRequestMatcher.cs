namespace Radish
{
    public abstract class AbstractRequestMatcher
    {
        protected readonly IRequestExtractor _extractor;

        public AbstractRequestMatcher(IRequestExtractor extractor)
        {
            _extractor = extractor;
        }


        public abstract bool IsMatch(IHttpRequest request);
    }
}