namespace Radish
{
    public interface IRequestExtractor
    {
        string Extract(IHttpRequest request);
    }
}