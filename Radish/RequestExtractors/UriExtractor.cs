namespace Radish.RequestExtractors
{
    internal class UriExtractor : IRequestExtractor
    {
        public string Extract(IHttpRequest request)
        {
            return request.Url.AbsolutePath;
        }
    }
}