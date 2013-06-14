using System.Collections.Generic;
using System.Text;

namespace Radish
{
    public class ResponseHandler : IHttpHandler
    {

        private readonly List<IResponseWriter> _writers;

        public ResponseHandler()
        {
            _writers = new List<IResponseWriter>();
        }


        public ResponseHandler File(string file)
        {
            _writers.Add(new ResponseFileWriter(file));
            return this;
        }

        public ResponseHandler Header(string name, string value)
        {
            _writers.Add(new ResponseHeaderWriter(name, value));
            return this;
        }

        public void Handle(IHttpContext context)
        {
            foreach (var responseWriter in _writers)
            {
                responseWriter.Write(context.Response);
            }
        }

        public ResponseHandler Text(string text)
        {
            _writers.Add(new ResponseTextWriter(text, Encoding.UTF8));
            return this;
        }
    }
}