using System;

namespace Radish.Matchers
{
    public class ExpressionRequestMatcher : IRequestMatcher
    {
        private readonly Func<IHttpRequest, bool> _expression;

        public ExpressionRequestMatcher(Func<IHttpRequest, bool> expression)
        {
            _expression = expression;
        }

        public bool Match(IHttpRequest request)
        {
            return _expression(request);
        }
    }
}
