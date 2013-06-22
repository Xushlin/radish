using System;

namespace Radish.Matchers
{
    public class ExpressionRequestMatcher : RequestMatcher
    {
        private readonly Func<IHttpRequest, bool> _expression;

        public ExpressionRequestMatcher(Func<IHttpRequest, bool> expression)
        {
            _expression = expression;
        }

        public override bool Match(IHttpRequest request)
        {
            return _expression(request);
        }
    }
}
