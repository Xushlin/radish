using System.Text.RegularExpressions;

namespace Radish.Matchers
{
    public class RegexRequestMatcher : RequestMatcher
    {
        private readonly IRequestExtractor _extractor;
        private readonly Regex _regex;


        public RegexRequestMatcher(IRequestExtractor extractor, string regex)
        {
            _extractor = extractor;
            _regex = new Regex(regex);
        }

        public override bool Match(IHttpRequest request)
        {
            var content = _extractor.Extract(request);
            return _regex.IsMatch(content);
        }
    }
}