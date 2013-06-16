namespace Radish.Matchers
{
    public class AnyRequestMatcher : AbstractRequestMatcher
    {
        public override bool Match(IHttpRequest request)
        {
            return true;
        }
    }
}