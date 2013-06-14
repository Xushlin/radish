using System;

namespace Radish.Matchers
{
    public class HttpMethodRequestMatcher : IRequestMatcher
    {
        private readonly string _httpMethod;

        public HttpMethodRequestMatcher(string httpMethod)
        {
            _httpMethod = httpMethod;
        }

        public bool Match(IHttpRequest request)
        {
            return request.HttpMethod.Equals(_httpMethod, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
