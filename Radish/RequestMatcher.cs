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
    }
}