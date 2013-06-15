using System.IO;
using System.Text;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Radish.Writers;

namespace Radish.UnitTests.Writers
{
    public class TextResponseWriterTests
    {
        [Test]
        public void Write()
        {
            // Arrange
            var responseStream = new MemoryStream();
            var response = Substitute.For<IHttpResponse>();
            response.OutputStream.Returns(responseStream);
            var fileWriter = new TextResponseWriter("test", Encoding.UTF8);

            // Act
            fileWriter.Write(response);

            // Assert
            responseStream.ToArray().Should().Equal(Encoding.UTF8.GetBytes("test"));
        }
    }
}
