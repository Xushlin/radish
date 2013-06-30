using System.IO;
using System.Text;

namespace Radish.RequestExtractors
{
    internal class ContentExtractor : IRequestExtractor
    {
        public string Extract(IHttpRequest request)
        {
            using (var stream = new MemoryStream())
            {
                request.InputStream.CopyTo(stream);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }
    }
}