using System.IO;
using System.Text;

namespace Radish.RequestExtractors
{
    public class ContentExtractor : IRequestExtractor
    {
        public string Extract(IHttpRequest request)
        {
            if (request.ContentLength64 > 0)
            {
                using (var stream = new MemoryStream())
                {
                    request.InputStream.CopyTo(stream);
                    return Encoding.UTF8.GetString(stream.ToArray());
                }
            }
            return null;
        }
    }
}