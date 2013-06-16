namespace Radish.RequestExtractors
{
    public class UriExtractor : IRequestExtractor
    {
        public string Extract(IHttpRequest request)
        {
            return request.Url.AbsolutePath;
        }
    }
}