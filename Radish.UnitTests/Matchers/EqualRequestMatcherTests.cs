using NSubstitute;
using NUnit.Framework;
using Radish.Matchers;

namespace Radish.UnitTests.Matchers
{
    public class EqualRequestMatcherTests
    {
        [Test]
        public void Match_for_are_equal()
        {
            // Arrange
            var extractor = Substitute.For<IRequestExtractor>();
            var request = Substitute.For<IHttpRequest>();
            extractor.Extract(request).ReturnsForAnyArgs("/home/index");
            var matcher = new EqualRequestMatcher(extractor, "/home/index");

            // Act
            var result = matcher.Match(request);

            // Assert
            Assert.True(result);
        }

        [Test]
        public void IsMatch_for_uri()
        {
            // Arrange
            var extractor = Substitute.For<IRequestExtractor>();
            var matcher = new EqualRequestMatcher(extractor, "/home/index");
            var request = Substitute.For<IHttpRequest>();

            extractor.Extract(request).ReturnsForAnyArgs("invalid");

            // Act
            var result = matcher.Match(request);

            // Assert
            Assert.False(result);
        }
    }
}
