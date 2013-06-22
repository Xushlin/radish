namespace Radish
{
    public interface IRequestMatcher
    {
        bool Match(IHttpRequest request);
    }
}