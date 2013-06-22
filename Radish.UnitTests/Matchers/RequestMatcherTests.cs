using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Radish.Matchers;

namespace Radish.UnitTests.Matchers
{
    public class RequestMatcherTests
    {
        [Test]
        public void OperatorAnd_should_create_new_AndRequestMatcher_by_matchers()
        {
            // Arrange
            var matcher1 = Substitute.For<RequestMatcher>();
            matcher1.Match(null).ReturnsForAnyArgs(true);

            var matcher2 = Substitute.For<RequestMatcher>();
            matcher2.Match(null).ReturnsForAnyArgs(false);

            // Act
            var result = matcher1 & matcher2;

            // Assert
            result.Should().BeOfType<AndRequestMatcher>();
            result.Match(null).Should().BeFalse();
        }

        [Test]
        public void OperatorOr_should_create_new_OrRequestMatcher_by_matchers()
        {
            // Arrange
            var matcher1 = Substitute.For<RequestMatcher>();
            matcher1.Match(null).ReturnsForAnyArgs(true);

            var matcher2 = Substitute.For<RequestMatcher>();
            matcher2.Match(null).ReturnsForAnyArgs(false);

            // Act
            var result = matcher1 | matcher2;

            // Assert
            result.Should().BeOfType<OrRequestMatcher>();
            result.Match(null).Should().BeTrue();
        }

        [Test]
        public void And_should_create_new_AndRequestMatcher_by_matchers()
        {
            // Arrange
            var matcher1 = Substitute.For<IRequestMatcher>();
            matcher1.Match(null).ReturnsForAnyArgs(true);

            var matcher2 = Substitute.For<IRequestMatcher>();
            matcher2.Match(null).ReturnsForAnyArgs(false);

            var matcher3 = Substitute.For<IRequestMatcher>();
            matcher3.Match(null).ReturnsForAnyArgs(false);

            // Act
            var result = RequestMatcher.And(matcher1, matcher2, matcher3);

            // Assert
            result.Should().BeOfType<AndRequestMatcher>();
            result.Match(null).Should().BeFalse();
        }

        [Test]
        public void Or_should_create_new_OrRequestMatcher_by_matchers()
        {
            // Arrange
            var matcher1 = Substitute.For<IRequestMatcher>();
            matcher1.Match(null).ReturnsForAnyArgs(true);

            var matcher2 = Substitute.For<IRequestMatcher>();
            matcher2.Match(null).ReturnsForAnyArgs(false);

            var matcher3 = Substitute.For<IRequestMatcher>();
            matcher3.Match(null).ReturnsForAnyArgs(false);

            // Act
            var result = RequestMatcher.Or(matcher1, matcher2, matcher3);

            // Assert
            result.Should().BeOfType<OrRequestMatcher>();
            result.Match(null).Should().BeTrue();
        }
    }
}
