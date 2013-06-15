using System.Text;

namespace Radish.Writers
{
    public class TextResponseWriter : IResponseWriter
    {
        private readonly string _text;
        private readonly Encoding _encoding;


        public TextResponseWriter(string text, Encoding encoding)
        {
            _text = text;
            _encoding = encoding;
        }

        public void Write(IHttpResponse response)
        {
            var buffer = _encoding.GetBytes(_text);
            response.OutputStream.Write(buffer, 0, buffer.Length);
        }
    }
}