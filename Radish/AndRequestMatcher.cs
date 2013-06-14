using System.Linq;

namespace Radish
{
    public class AndRequestMatcher : AbstractRequestMatcher
    {
        private readonly IRequestMatcher[] _matchers;

        public AndRequestMatcher(params IRequestMatcher[] matchers)
        {
            _matchers = matchers;
        }


        public override bool Match(IHttpRequest request)
        {
            return _matchers.All(matcher => matcher.Match(request));
        }
    }
}