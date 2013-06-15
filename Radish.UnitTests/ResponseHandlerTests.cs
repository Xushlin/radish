using NSubstitute;
using NUnit.Framework;

namespace Radish.UnitTests
{
    public class ResponseHandlerTests
    {
        [Test]
        public void Header_should_append_a_HeaderResponseWriter()
        {
            // Arrange
            var handler = new ResponseHandler();
            var httpContext = Substitute.For<IHttpContext>();
    

            // Act
            handler.Header("Content-Type", "text/xml");
            handler.Handle(httpContext);

            // Assert
            httpContext.Response.Received().AppendHeader("Content-Type", "text/xml");
        }
    }
}
