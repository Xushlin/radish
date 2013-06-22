namespace Radish.Matchers
{
    public class AnyRequestMatcher : RequestMatcher
    {
        public override bool Match(IHttpRequest request)
        {
            return true;
        }
    }
}