namespace Radish
{
    public abstract class AbstractRequestMatcher
    {
        public abstract bool IsMatch(IHttpRequest request);

        public static AbstractRequestMatcher operator &(AbstractRequestMatcher matcher1, AbstractRequestMatcher matcher2)
        {
            return new AndRequestMatcher(matcher1, matcher2);
        }
    }
}