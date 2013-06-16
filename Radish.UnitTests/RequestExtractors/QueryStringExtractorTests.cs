using System.Collections.Specialized;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Radish.RequestExtractors;

namespace Radish.UnitTests.RequestExtractors
{
    class QueryStringExtractorTests
    {
        [Test]
        public void Extract_should_return_specified_query_string_value()
        {
            // Arrange
            var request = Substitute.For<IHttpRequest>();
            request.QueryString.Returns(new NameValueCollection() { { "name", "value" } });
            var extractor = new QueryStringExtractor("name");

            // Act
            var result = extractor.Extract(request);

            // Assert
            var expected = "value";
            result.Should().Be(expected);
        }
    }
}
