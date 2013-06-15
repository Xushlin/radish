using FluentAssertions;
using NUnit.Framework;

namespace Radish.IntegrationTests
{
    public class HttpServerTests
    {
        [Test]
        public void Handle_when_matched_request_should_reponse_setting_content()
        {
            // Assert
            var httpServer = new HttpServer();
            httpServer.When(request => request.Uri.Is("/home/index"))
                      .Then(response => response.Text("hello"));

            var httpEngine = new HttpServerEngine(httpServer, 9000);
            httpEngine.Start();

            // Act
            var result = Http.Get("http://localhost:9000/home/index").GetContent();
            httpEngine.Stop();

            // Assert
            result.Should().Be("hello");
        }

        [Test]
        public void Handle_when_request_not_matched_should_return_404()
        {
            // Assert
            var httpServer = new HttpServer();

            var httpEngine = new HttpServerEngine(httpServer, 9000);
            httpEngine.Start();

            // Act
            var result = Http.Get("http://localhost:9000/home/index").GetContent();
            httpEngine.Stop();

            // Assert
            result.Should().Be(string.Empty);
        }
    }
}
