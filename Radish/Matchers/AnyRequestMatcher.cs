using System.Net;

namespace Radish.Matchers
{
    public class AnyRequestMatcher : IRequestMatcher
    {
        public  bool Match(IHttpRequest request)
        {
            return true;
        }
    }
}