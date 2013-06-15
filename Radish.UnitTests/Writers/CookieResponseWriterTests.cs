using System.Net;
using NSubstitute;
using NUnit.Framework;
using Radish.Writers;

namespace Radish.UnitTests.Writers
{
    public class CookieResponseWriterTests
    {
        [Test]
        public void Writer()
        {
            // Arrange
            var headers = new WebHeaderCollection();
            var writer = new CookieResponseWriter("cookie-name", "cookie-value");
            var response = Substitute.For<IHttpResponse>();
            response.Headers.Returns(headers);

            // Act
            writer.Write(response);

            // Assert
            response.Received().AppendCookie(new Cookie("cookie-name", "cookie-value"));
        }
    }
}
