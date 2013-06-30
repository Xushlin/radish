using System;

namespace Radish.Writers
{
    internal class StatusCodeResponseWriter : IResponseWriter
    {
        private readonly int _statusCode;

        public StatusCodeResponseWriter(int statusCode)
        {
            _statusCode = statusCode;
        }

        public void Write(IHttpResponse response)
        {
            response.StatusCode = _statusCode;
        }
    }
}