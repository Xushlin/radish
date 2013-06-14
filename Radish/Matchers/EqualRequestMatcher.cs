using Radish.Extensions;
using Radish.Helpers;

namespace Radish.Matchers
{
    public class EqualRequestMatcher : IRequestMatcher
    {
        private readonly IRequestExtractor _extractor;
        private readonly IResource _resource;

        public EqualRequestMatcher(IRequestExtractor extractor, IResource resource)
        {
            _extractor = extractor;
            _resource = resource;
        }

        public bool Match(IHttpRequest request)
        {
            var content = _extractor.Extract(request);

            return content != null && ArrayHelper.Equals(content.ToByteArray(), _resource.ToByteArray());
        }
    }
}