using System;

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
}