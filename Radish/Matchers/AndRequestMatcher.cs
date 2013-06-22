using System.Collections.Generic;
using System.Linq;

namespace Radish.Matchers
{
    public class AndRequestMatcher : RequestMatcher
    {
        private readonly IEnumerable<IRequestMatcher> _matchers;

        public AndRequestMatcher(params IRequestMatcher[] matchers)
        {
            _matchers = matchers;
        }

        public override bool Match(IHttpRequest request)
        {
            return _matchers.All(x => x.Match(request));
        }
    }
}