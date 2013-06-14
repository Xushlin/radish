using System;

namespace Radish.Extractors
{
    public class UriRequestExtractor : IRequestExtractor
    {
        public string Extract(IHttpRequest request)
        {
            return request.Url.PathAndQuery;
        }
    }
}