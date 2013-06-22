using Radish.Matchers;

namespace Radish
{
    public abstract class RequestMatcher : IRequestMatcher
    {
        public abstract bool Match(IHttpRequest request);

        public static RequestMatcher operator &(RequestMatcher matcher1, RequestMatcher matcher2)
        {
            return new AndRequestMatcher(matcher1, matcher2);
        }

        public static RequestMatcher operator |(RequestMatcher matcher1, RequestMatcher matcher2)
        {
            return new OrRequestMatcher(matcher1, matcher2);
        }

        public static IRequestMatcher And(params IRequestMatcher[] matchers)
        {
            return new AndRequestMatcher(matchers);
        }

        public static IRequestMatcher Or(params IRequestMatcher[] matchers)
        {
            return new OrRequestMatcher(matchers);
        }
    }
}