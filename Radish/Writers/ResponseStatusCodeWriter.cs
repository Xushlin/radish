using System;

namespace Radish.Writers
{
    public class ResponseStatusCodeWriter : IResponseWriter
    {
        private readonly int _statusCode;

        public ResponseStatusCodeWriter(int statusCode)
        {
            _statusCode = statusCode;
        }

        public void Write(IHttpResponse response)
        {
            throw new NotImplementedException();
        }
    }
}