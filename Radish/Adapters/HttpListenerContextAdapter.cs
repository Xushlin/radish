using System.Net;

namespace Radish.Adapters
{
    public class HttpListenerContextAdapter : IHttpContext
    {
        private readonly HttpListenerContext _context;
        public IHttpRequest Request { get; private set; }
        public IHttpResponse Response { get; private set; }

        public HttpListenerContextAdapter(HttpListenerContext context)
        {
            _context = context;
            Request = new HttpListenerRequestAdapter(_context.Request);
            Response = new HttpListenerResponseAdapter(_context.Response);
        }
    }
}
