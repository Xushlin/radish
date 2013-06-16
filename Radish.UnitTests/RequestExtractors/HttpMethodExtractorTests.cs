using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Radish.RequestExtractors;

namespace Radish.UnitTests.RequestExtractors
{
    public class HttpMethodExtractorTests
    {
        [Test]
        public void Extract_should_return_request_http_method()
        {
            // Arrange
            var request = Substitute.For<IHttpRequest>();
            request.HttpMethod.Returns("GET");
            var extractor = new HttpMethodExtractor();

            // Act
            var result = extractor.Extract(request);

            // Assert
            var expected = "GET";
            result.Should().Be(expected);
        }
    }
}
