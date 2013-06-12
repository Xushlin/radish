using System.Linq;

namespace Radish
{
    public class AndRequestMatcher : AbstractRequestMatcher
    {
        private readonly AbstractRequestMatcher[] _matchers;

        public AndRequestMatcher(params AbstractRequestMatcher[] matchers)
        {
            _matchers = matchers;
        }


        public override bool IsMatch(IHttpRequest request)
        {
            return _matchers.All(matcher => matcher.IsMatch(request));
        }
    }
}