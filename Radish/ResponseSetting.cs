using System.Collections.Generic;

namespace Radish
{
    public class ResponseSetting
    {
        private readonly IHttpResponse _response;
        
        private readonly List<IResponseWriter> _writers;

        public ResponseSetting(IHttpResponse response)
        {
            _response = response;
            _writers = new List<IResponseWriter>();
        }


        public ResponseSetting File(string file)
        {
            _writers.Add(new ResponseFileWriter(file));
            return this;
        }

        public ResponseSetting Header(string name, string value)
        {
            _writers.Add(new ResponseHeaderWriter(name, value));
            return this;
        }
    }
}