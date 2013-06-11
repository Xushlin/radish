using System;

namespace Radish
{
    public class ResponseHeaderWriter : IResponseWriter
    {
        private readonly string _name;
        private readonly string _value;

        public ResponseHeaderWriter(string name, string value)
        {
            _name = name;
            _value = value;
        }

        public void Write(IHttpResponse response)
        {
            throw new NotImplementedException();
        }
    }
}