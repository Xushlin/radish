using FluentAssertions;
using NUnit.Framework;
using Radish.Helpers;

namespace Radish.UnitTests
{
    public class HttpTest
    {
        [Test]
        public void Get()
        {
            // Arrange
            var url = "http://www.baidu.com";

            // Act
            ResponseResult result = Http.Get(url);

            // Assert
            result.GetContent().Should().NotBeNull();
        }
    }
}
