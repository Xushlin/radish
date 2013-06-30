using System;
using System.IO;

namespace Radish.Writers
{
    internal class FileResponseWriter : IResponseWriter
    {
        private readonly string _file;

        public FileResponseWriter(string file)
        {
            _file = file;
        }

        public void Write(IHttpResponse response)
        {
            byte[] content = File.ReadAllBytes(_file);
            response.OutputStream.Write(content, 0, content.Length);
        }
    }
}