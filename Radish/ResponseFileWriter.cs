using System;
using System.Text;

namespace Radish
{
    public class ResponseFileWriter : IResponseWriter
    {
        private readonly string _file;

        public ResponseFileWriter(string file)
        {
            _file = file;
        }

        public void Write(IHttpResponse response)
        {
            throw new NotImplementedException();
        }
    }

    public class ResponseTextWriter : IResponseWriter
    {
        private readonly string _text;
        private readonly Encoding _encoding;


        public ResponseTextWriter(string text, Encoding encoding)
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