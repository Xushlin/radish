using System.Collections.Generic;

namespace Radish
{
    public class ResponseSetting
    {

        private readonly List<IResponseWriter> _writers;

        public ResponseSetting()
        {
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