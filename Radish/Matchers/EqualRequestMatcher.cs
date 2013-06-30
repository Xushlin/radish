namespace Radish.Matchers
{
    internal class EqualRequestMatcher : RequestMatcher
    {
        private readonly IRequestExtractor _extractor;
        private readonly string _expected;

        public EqualRequestMatcher(IRequestExtractor extractor, string expected)
        {
            _extractor = extractor;
            _expected = expected;
        }

        public override bool Match(IHttpRequest request)
        {
            var content = _extractor.Extract(request);
            return content != null && content.Equals(_expected);
        }
    }
}