namespace Radish.Extractors
{
    public class HttpMethodRequestExtractor : IRequestExtractor
    {
        public string Extract(IHttpRequest request)
        {
            return request.HttpMethod;
        }
    }
}