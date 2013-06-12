using System;

namespace Radish
{
    public class EqualRequestMatcher : AbstractRequestMatcher
    {
        private readonly IRequestExtractor _extractor;
        private readonly string _expected;

        public EqualRequestMatcher(IRequestExtractor extractor, string expected)
        {
            _extractor = extractor;
            _expected = expected;
        }


        public override bool IsMatch(IHttpRequest request)
        {
            return _extractor.Extract(request).Equals(_expected);
        }
    }
}