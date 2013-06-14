using System.Collections.Generic;
using System.Linq;

namespace Radish.Matchers
{
    public class AndRequestMatcher : IRequestMatcher
    {
        private readonly IEnumerable<IRequestMatcher> _matchers;

        public AndRequestMatcher(IEnumerable<IRequestMatcher> matchers)
        {
            _matchers = matchers;
        }

        public bool Match(IHttpRequest request)
        {
            return _matchers.All(x => x.Match(request));
        }
    }
}