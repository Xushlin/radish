using System;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Radish.RequestExtractors;

namespace Radish.UnitTests.RequestExtractors
{
    public class UriExtractorTests
    {
        [Test]
        public void Extract_should_return_request_absolute_path()
        {
            // Arrange
            var request = Substitute.For<IHttpRequest>();
            request.Url.Returns(new Uri("http://localhost/home/index?param=value"));
            var extractor = new UriExtractor();

            // Act
            var result = extractor.Extract(request);

            // Assert
            var expected = "/home/index";
            result.Should().Be(expected);
        }
    }
}
