using NUnit.Framework;

namespace Radish.UnitTests
{
    public class HttpServerTest
    {
        [Test]
        public void Create()
        {
            // Arrange

            // Act
            var server = new HttpServer();

            // Assert
            Assert.NotNull(server);
        }

        [Test]
        public void Run()
        {
            // Arrange
            var server = new HttpServer();
            server.When(request => request.Uri.Is("/home/index"))
                  .Then(response => response.Text("foo"));

            var engine = new HttpServerEngine(server,9000).Start();

            // Act
            var result = Http.Get("http://localhost:9000/home/index").GetContent();
            engine.Stop();

            // Assert
            Assert.That(result, Is.EqualTo("foo"));
        }
    }
}
