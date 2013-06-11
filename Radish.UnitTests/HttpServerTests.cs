using NUnit.Framework;

namespace Radish.UnitTests
{
    public class HttpServerTests
    {
        [Test]
        public void MappingTest()
        {
            var server = new HttpServer();
            server.When(request => request.Uri.Is("home/index"))
                  .Then(response => response.File("c:\\test.html").Header("Accept", "text/html"));
        }
    }
}
