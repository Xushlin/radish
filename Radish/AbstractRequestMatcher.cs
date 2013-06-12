namespace Radish
{
    public interface IRequestMatcher
    {
        bool IsMatch(IHttpRequest request);
    }

    public abstract class AbstractRequestMatcher : IRequestMatcher
    {
        public abstract bool IsMatch(IHttpRequest request);

        public static AbstractRequestMatcher operator &(AbstractRequestMatcher matcher1, AbstractRequestMatcher matcher2)
        {
            return new AndRequestMatcher(matcher1, matcher2);
        }
    }
}