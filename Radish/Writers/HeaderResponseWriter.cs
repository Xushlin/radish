using System;

namespace Radish.Writers
{
    internal class HeaderResponseWriter : IResponseWriter
    {
        private readonly string _name;
        private readonly string _value;

        public HeaderResponseWriter(string name, string value)
        {
            _name = name;
            _value = value;
        }

        public void Write(IHttpResponse response)
        {
            response.AppendHeader(_name, _value);
        }
    }
}