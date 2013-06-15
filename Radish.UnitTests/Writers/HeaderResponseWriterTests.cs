using System.Net;
using NSubstitute;
using NUnit.Framework;
using Radish.Writers;

namespace Radish.UnitTests.Writers
{
    public class HeaderResponseWriterTests
    {
        [Test]
        public void Write()
        {
            // Arrange
            var headers = new WebHeaderCollection();
            var writer = new HeaderResponseWriter("Content-Type", "text/xml");
            var response = Substitute.For<IHttpResponse>();
            response.Headers.Returns(headers);

            // Act
            writer.Write(response);

            // Assert
            response.Received(1).AppendHeader("Content-Type","text/xml");
        }
    }
}
