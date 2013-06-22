using FluentAssertions;
using NUnit.Framework;
using Radish.Matchers;

namespace Radish.UnitTests.Matchers
{
    public class AnyRequestMatcherTests
    {
        [Test]
        public void Match_should_always_return_true()
        {
            // Arrange
            var matcher = new AnyRequestMatcher();

            // Act
            var result = matcher.Match(null);

            // Assert
            result.Should().BeTrue();
        }
    }
}
