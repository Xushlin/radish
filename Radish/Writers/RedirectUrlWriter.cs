namespace Radish.Writers
{
    public class RedirectUrlWriter : IResponseWriter
    {
        private readonly string _url;

        public RedirectUrlWriter(string url)
        {
            _url = url;
        }

        public void Write(IHttpResponse response)
        {
            response.Redirect(_url);
        }
    }
}
