using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Radish.Writers;

namespace Radish.UnitTests
{
    public class ResponseHandlerTests
    {
        [Test]
        public void Header_should_append_a_HeaderResponseWriter()
        {
            // Arrange
            var setting = new ResponseSetting();

            // Act
            setting.Header("Content-Type", "text/xml");

            // Assert
            setting.Writers.First().Should().BeOfType<HeaderResponseWriter>();
            setting.Writers.Count().Should().Be(1);
        }

        [Test]
        public void File_should_append_a_FileResponseWriter()
        {
            // Arrange
            var setting = new ResponseSetting();

            // Act
            setting.File("test.txt");

            // Assert
            setting.Writers.First().Should().BeOfType<FileResponseWriter>();
            setting.Writers.Count().Should().Be(1);
        }

        [Test]
        public void Text_should_append_a_TextResponseWriter()
        {
            // Arrange
            var setting = new ResponseSetting();

            // Act
            setting.Text("hello");

            // Assert
            setting.Writers.First().Should().BeOfType<TextResponseWriter>();
            setting.Writers.Count().Should().Be(1);
        }

        [Test]
        public void Status_should_append_a_StatusCodeResponseWriter()
        {
            // Arrange
            var setting = new ResponseSetting();

            // Act
            setting.Status(404);

            // Assert
            setting.Writers.First().Should().BeOfType<StatusCodeResponseWriter>();
            setting.Writers.Count().Should().Be(1);
        }

        [Test]
        public void Cookie_should_append_a_CookieCodeResponseWriter()
        {
            // Arrange
            var setting = new ResponseSetting();

            // Act
            setting.Cookie("cookie-name", "cookie-value");

            // Assert
            setting.Writers.First().Should().BeOfType<CookieResponseWriter>();
            setting.Writers.Count().Should().Be(1);
        }
    }
}
