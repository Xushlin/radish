using System.IO;
using System.Text;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Radish.Writers;

namespace Radish.UnitTests.Writers
{
    public class FileResponseWriterTests
    {
        [Test]
        public void Write()
        {
            // Arrange
            var responseStream = new MemoryStream();
            var response = Substitute.For<IHttpResponse>();
            response.OutputStream.Returns(responseStream);
            var fileWriter = new FileResponseWriter("test.txt");

            // Act
            fileWriter.Write(response);

            // Assert
            Encoding.UTF8.GetString(responseStream.ToArray()).Should().Be("hello");
        }
    }
}
