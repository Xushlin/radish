using System.Collections.Generic;
using System.Linq;

namespace Radish.Matchers
{
    public class OrRequestMatcher : RequestMatcher
    {
        private readonly IEnumerable<IRequestMatcher> _matchers;

        public OrRequestMatcher(params IRequestMatcher[] matchers)
            : this((IEnumerable<IRequestMatcher>)matchers)
        {
        }

        public OrRequestMatcher(IEnumerable<IRequestMatcher> matchers)
        {
            _matchers = matchers;
        }

        public override bool Match(IHttpRequest request)
        {
            return _matchers.Any(x => x.Match(request));
        }
    }
}