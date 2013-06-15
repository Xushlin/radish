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
    }
}
