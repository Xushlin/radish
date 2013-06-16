using System.Collections.Generic;
using System.Text;
using Radish.Writers;

namespace Radish
{
    public class ResponseSetting
    {
        private readonly List<IResponseWriter> _writers;

        public ResponseSetting()
        {
            _writers = new List<IResponseWriter>();
        }

        public IEnumerable<IResponseWriter> Writers
        {
            get { return _writers; }
        }

        public ResponseSetting File(string file)
        {
            _writers.Add(new FileResponseWriter(file));
            return this;
        }

        public ResponseSetting Header(string name, string value)
        {
            _writers.Add(new HeaderResponseWriter(name, value));
            return this;
        }

        public ResponseSetting Text(string text)
        {
            _writers.Add(new TextResponseWriter(text, Encoding.UTF8));
            return this;
        }

        public ResponseSetting Status(int statusCode)
        {
            _writers.Add(new StatusCodeResponseWriter(statusCode));
            return this;
        }

        public ResponseSetting Cookie(string cookieName, string cookieValue)
        {
            _writers.Add(new CookieResponseWriter(cookieName, cookieValue));
            return this;
        }
    }
}