using Radish.Matchers;

namespace Radish
{
    public interface IRequestMatcher
    {
        bool Match(IHttpRequest request);
    }

    public abstract class AbstractRequestMatcher : IRequestMatcher
    {
        public abstract bool Match(IHttpRequest request);

        public static AbstractRequestMatcher operator &(AbstractRequestMatcher matcher1, AbstractRequestMatcher matcher2)
        {
//            var matcher = matcher1 as AndRequestMatcher;
//            if (matcher != null)
//            {
//                matcher.AppendMatcher(matcher2);
//                return matcher1;
//            }
//
//            matcher = matcher2 as AndRequestMatcher;
//            if (matcher != null)
//            {
//                matcher.AppendMatcher(matcher1);
//                return matcher2;
//            }

            return new AndRequestMatcher(matcher1, matcher2);
        }

        public static AbstractRequestMatcher operator |(AbstractRequestMatcher matcher1, AbstractRequestMatcher matcher2)
        {
//            var matcher = matcher1 as OrRequestMatcher;
//            if (matcher != null)
//            {
//                matcher.AppendMatcher(matcher2);
//                return matcher1;
//            }
//
//            matcher = matcher2 as OrRequestMatcher;
//            if (matcher != null)
//            {
//                matcher.AppendMatcher(matcher1);
//                return matcher2;
//            }

            return new OrRequestMatcher(matcher1, matcher2);
        }
    }
}