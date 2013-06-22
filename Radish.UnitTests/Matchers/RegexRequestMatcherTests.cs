
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Radish.Matchers;

namespace Radish.UnitTests.Matchers
{
    public class RegexRequestMatcherTests
    {
        [Test]
        public void Match_when_regex_is_matched_should_return_true()
        {
            // Arrange
            var extractor = Substitute.For<IRequestExtractor>();
            var request = Substitute.For<IHttpRequest>();
            extractor.Extract(request).ReturnsForAnyArgs("/home/index");
            var matcher = new RegexRequestMatcher(extractor, "^/home/");

            // Act
            var result = matcher.Match(request);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void Match_when_regex_is_not_matched_should_return_false()
        {
            // Arrange
            var extractor = Substitute.For<IRequestExtractor>();
            var request = Substitute.For<IHttpRequest>();
            extractor.Extract(request).ReturnsForAnyArgs("/home/index");
            var matcher = new RegexRequestMatcher(extractor, "^/invlid/");

            // Act
            var result = matcher.Match(request);

            // Assert
            result.Should().BeFalse();
        }
    }
}
