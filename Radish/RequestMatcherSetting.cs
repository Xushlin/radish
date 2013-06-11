namespace Radish
{
    public class RequestMatcherSetting
    {
        private readonly IHttpRequest _request;

        public RequestMatcherSetting(IHttpRequest request)
        {
            _request = request;
        }

        protected IRequestExtractor _extractor;

        public bool Is(string expected)
        {
            return new EqualRequestMatcher(_extractor, expected).IsMatch(_request);
        }
    }
}