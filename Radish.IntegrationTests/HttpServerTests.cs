using System.Net;
using FluentAssertions;
using NUnit.Framework;
using Radish.Helpers;

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
            var exception = Assert.Throws<WebException>(() => Http.Get("http://localhost:9000/home/index").GetContent());
            httpEngine.Stop();

            // Assert
            exception.Should().NotBeNull();
            ((HttpWebResponse)exception.Response).StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Test]
        public void Handle_for_multi_matcher()
        {
            // Assert
            var server = new HttpServer();
            server.When(request=> request.Uri.Is("/home/index") & request.Method.Is("GET"))
                  .Then(response => response.Text("foo"));

            var httpEngine = HttpServerEngine.StartNew(server, 9000);

            // Act
            var result = Http.Get("http://localhost:9000/home/index").GetContent();
            httpEngine.Stop();

            // Assert
            result.Should().Be("foo");
        }
    }
}
