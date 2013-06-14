using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Radish.Matchers
{
    public class OrRequestMatcher : IRequestMatcher
    {
        private readonly IEnumerable<IRequestMatcher> _matchers;

        public OrRequestMatcher(IEnumerable<IRequestMatcher> matchers)
        {
            _matchers = matchers;
        }

        public  bool Match(IHttpRequest request)
        {
            return _matchers.Any(x => x.Match(request));
        }
    }
}