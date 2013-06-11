using System;

namespace Radish
{
    public class EqualRequestMatcher : AbstractRequestMatcher
    {
        private readonly object _expected;

        public EqualRequestMatcher(IRequestExtractor extractor, object expected)
            : base(extractor)
        {
            _expected = expected;
        }


        public override bool IsMatch(IHttpRequest request)
        {
            throw new NotImplementedException();
        }
    }
}