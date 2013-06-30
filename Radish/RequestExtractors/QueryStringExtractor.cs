namespace Radish.RequestExtractors
{
    internal class QueryStringExtractor : IRequestExtractor
    {
        private readonly string _paramName;

        public QueryStringExtractor(string paramName)
        {
            _paramName = paramName;
        }

        public string Extract(IHttpRequest request)
        {
            return request.QueryString[_paramName];
        }
    }
}