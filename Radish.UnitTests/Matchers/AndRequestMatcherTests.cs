using NSubstitute;
using NUnit.Framework;
using Radish.Matchers;

namespace Radish.UnitTests.Matchers
{
    public class AndRequestMatcherTests
    {
        [Test]
        public void Match_when_all_matchers_are_matched_should_return_true()
        {
            // Arrange
            var matcher1 = Substitute.For<IRequestMatcher>();
            matcher1.Match(null).ReturnsForAnyArgs(true);

            var matcher2 = Substitute.For<IRequestMatcher>();
            matcher2.Match(null).ReturnsForAnyArgs(true);

            var andRequestMatcher = new AndRequestMatcher(new[] { matcher1, matcher2 });

            // Act
            var result = andRequestMatcher.Match(null);

            // Assert
            Assert.True(result);
        }


        [Test]
        public void Match_when_matchers_has_any_unmatched_should_return_false()
        {
            // Arrange
            var matcher1 = Substitute.For<IRequestMatcher>();
            matcher1.Match(null).ReturnsForAnyArgs(true);

            var matcher2 = Substitute.For<IRequestMatcher>();
            matcher2.Match(null).ReturnsForAnyArgs(false);

            var andRequestMatcher = new AndRequestMatcher(new[] { matcher1, matcher2 });

            // Act
            var result = andRequestMatcher.Match(null);

            // Assert
            Assert.False(result);
        }
    }
}
