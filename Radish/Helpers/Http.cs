using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Radish.Helpers
{
    public class Http
    {
        public static HttpResult Get(string url)
        {
            HttpWebResponse response;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AllowAutoRedirect = false;
            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }
            catch (WebException exc)
            {
                response = exc.Response as HttpWebResponse;
            }

            return new HttpResult(response);
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

    public class HttpResult
    {
        private readonly HttpWebResponse _response;
        private readonly byte[] _content;
        public HttpStatusCode StatusCode { get { return _response.StatusCode; } }
        public string RedirectUrl { get { return _response.Headers["Location"]; } }
        public string Content
        {
            get
            {
                var encoding = string.IsNullOrEmpty(_response.ContentEncoding) ? Encoding.UTF8 : Encoding.GetEncoding(_response.ContentEncoding);

                using (var reader = new StreamReader(new MemoryStream(_content), encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public HttpResult(HttpWebResponse response)
        {
            _response = response;

            if (response.StatusCode == HttpStatusCode.Redirect)
            {

            }

            if (_response.ContentLength > 0)
            {
                _content = new byte[_response.ContentLength];
                Stream stream = _response.GetResponseStream();
                int index = 0;
                while (index < _content.Length)
                {
                    _content[index] = (byte)stream.ReadByte();
                    index++;
                }
            }
            else
            {
                Stream stream = _response.GetResponseStream();
                List<byte> buffer = new List<byte>();
                int data = stream.ReadByte();
                while (data > -1)
                {
                    buffer.Add((byte)data);
                    data = stream.ReadByte();
                }
                _content = buffer.ToArray();
            }

        }


    }
}
