namespace Radish.Matchers
{
    internal class AnyRequestMatcher : RequestMatcher
    {
        public override bool Match(IHttpRequest request)
        {
            return true;
        }
    }
}