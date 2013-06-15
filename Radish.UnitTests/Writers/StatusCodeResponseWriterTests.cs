using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Radish.Writers;

namespace Radish.UnitTests.Writers
{
    public class StatusCodeResponseWriterTests
    {
        [Test]
        public void Write()
        {
            // Arrange
            var writer = new StatusCodeResponseWriter(404);
            var response = Substitute.For<IHttpResponse>();

            // Act
            writer.Write(response);

            // Assert
            response.StatusCode.Should().Be(404);
        }
    }
}
