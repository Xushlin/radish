using System;
using System.IO;

namespace Radish.Writers
{
    public class FileResponseWriter : IResponseWriter
    {
        private readonly string _file;

        public FileResponseWriter(string file)
        {
            _file = file;
        }

        public void Write(IHttpResponse response)
        {
            using (var stream = File.Open(_file, FileMode.Open))
            {
                var data = (byte)stream.ReadByte();
                while (data != -1)
                {
                    response.OutputStream.WriteByte(data);
                    data = (byte)stream.ReadByte();
                }
            }
        }
    }
}