namespace Radish.RequestExtractors
{
    internal class HttpMethodExtractor : IRequestExtractor
    {
        public string Extract(IHttpRequest request)
        {
            return request.HttpMethod;
        }
    }
}