namespace Radish
{
    public interface IRequestMatcher
    {
        bool Match(IHttpRequest request);
    }

    public abstract class AbstractRequestMatcher : IRequestMatcher
    {
        public abstract bool Match(IHttpRequest request);

        public static AbstractRequestMatcher operator &(AbstractRequestMatcher matcher1, AbstractRequestMatcher matcher2)
        {
            return new AndRequestMatcher(matcher1, matcher2);
        }
    }
}