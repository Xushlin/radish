using System;

namespace Radish.Matchers
{
    public class HttpMethodRequestMatcher : AbstractRequestMatcher
    {
        private readonly string _httpMethod;

        public HttpMethodRequestMatcher(string httpMethod)
        {
            _httpMethod = httpMethod;
        }

        public override bool Match(IHttpRequest request)
        {
            return request.HttpMethod.Equals(_httpMethod, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
