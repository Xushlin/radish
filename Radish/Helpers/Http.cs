using System.IO;
using System.Net;
using System.Text;

namespace Radish.Helpers
{
    public class Http
    {
        public static string Get(string url)
        {
            HttpWebResponse response;
            var request = (HttpWebRequest)WebRequest.Create(url);
            string result = null;

            response = request.GetResponse() as HttpWebResponse;

            // we will read data via the response stream
            var encoding = string.IsNullOrEmpty(response.ContentEncoding) ? Encoding.UTF8 : Encoding.GetEncoding(response.ContentEncoding);
            var streamReader = new StreamReader(response.GetResponseStream(), encoding);
            result = streamReader.ReadToEnd();



            return result;

        }

        // TODO: add unit tests for put and post methods
        //        public static object Put(string url, string data)
        //        {
        //            HttpWebResponse response;
        //            var request = (HttpWebRequest)WebRequest.Create(url);
        //            string result = null;
        //            try
        //            {
        //
        //                byte[] arr = Encoding.UTF8.GetBytes(data);
        //
        //                request.Timeout = 10000;
        //                request.Method = "PUT";
        //                request.Headers.Add("X-API-KEY", "6GjfU7ru");
        //                request.ContentType = "application/x-www-form-urlencoded";
        //                request.ContentLength = arr.Length;
        //
        //                request.Accept = "text/json";
        //                request.ProtocolVersion = HttpVersion.Version11;
        //                Stream dataStream = request.GetRequestStream();
        //                dataStream.Write(arr, 0, arr.Length);
        //                dataStream.Close();
        //                response = (HttpWebResponse)request.GetResponse();
        //
        //            }
        //            catch (WebException exc)
        //            {
        //                response = (HttpWebResponse)exc.Response;
        //            }
        //            if (response != null)
        //            {
        //                // we will read data via the response stream
        //                var encoding = string.IsNullOrEmpty(response.ContentEncoding) ? Encoding.UTF8 : Encoding.GetEncoding(response.ContentEncoding);
        //                var streamReader = new StreamReader(response.GetResponseStream(), encoding);
        //                result = streamReader.ReadToEnd();
        //            }
        //
        //
        //            return result;
        //        }
        //
        public static string Post(string url, string postData)
        {
            HttpWebResponse response;
            var request = (HttpWebRequest)WebRequest.Create(url);
            string result = null;


            var arr = Encoding.UTF8.GetBytes(postData);

            request.Timeout = 10000;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = arr.Length;
            request.ProtocolVersion = HttpVersion.Version11;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(arr, 0, arr.Length);
            dataStream.Close();
            response = (HttpWebResponse)request.GetResponse();


            // we will read data via the response stream
            var encoding = string.IsNullOrEmpty(response.ContentEncoding) ? Encoding.UTF8 : Encoding.GetEncoding(response.ContentEncoding);
            var streamReader = new StreamReader(response.GetResponseStream(), encoding);
            result = streamReader.ReadToEnd();



            return result;
        }

    }
}
