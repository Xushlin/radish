using System;
using NSubstitute;
using NUnit.Framework;
using Radish.Extractors;

namespace Radish.UnitTests
{
    public class RequestExtractorTest
    {
        [Test]
        public void UrlRequestExtractor()
        {
            // Arrange
            var request = Substitute.For<IHttpRequest>();
            request.Url.Returns(new Uri("http://www.google.com/test"));
            var extractor = new UriRequestExtractor();

            // Act
            var result = extractor.Extract(request);

            // Assert
            Assert.AreEqual(result,"/test");
        }
    }
}
