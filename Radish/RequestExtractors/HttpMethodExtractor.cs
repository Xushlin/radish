namespace Radish.RequestExtractors
{
    public class HttpMethodExtractor : IRequestExtractor
    {
        public string Extract(IHttpRequest request)
        {
            return request.HttpMethod;
        }
    }
}