using System;
using System.IO;
using System.Net;
using System.Text;

namespace Radish
{
    public class Http
    {
        public static ResponseResult Get(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            return ResponseResult.Text((HttpWebResponse)request.GetResponse());
        }

        public static object Put(string url, string data)
        {
            HttpWebResponse response;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            string result = null;
            try
            {

                byte[] arr = Encoding.UTF8.GetBytes(data);

                request.Timeout = 10000;
                request.Method = "PUT";
                request.Headers.Add("X-API-KEY", "6GjfU7ru");
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = arr.Length;

                request.Accept = "text/json";
                request.ProtocolVersion = System.Net.HttpVersion.Version11;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(arr, 0, arr.Length);
                dataStream.Close();
                response = (HttpWebResponse)request.GetResponse();

            }
            catch (WebException exc)
            {
                response = (HttpWebResponse)exc.Response;
            }
            if (response != null)
            {
                // we will read data via the response stream
                Stream resStream = response.GetResponseStream();

                Encoding encoding = string.IsNullOrEmpty(response.CharacterSet) ? Encoding.UTF8 : Encoding.GetEncoding(response.ContentEncoding);

                StreamReader streamReader = new StreamReader(
                                              resStream,
                                              encoding
                                            );
                result = streamReader.ReadToEnd();
            }


            return result;
        }

        public static object Post(string url, string data)
        {
            HttpWebResponse response;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            string result = null;
            try
            {

                byte[] arr = Encoding.UTF8.GetBytes(data);

                request.Timeout = 10000;
                request.Method = "POST";
                request.Headers.Add("X-API-KEY", "6GjfU7ru");
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = arr.Length;
                request.KeepAlive = true;
                request.Accept = "text/html";
                request.ProtocolVersion = System.Net.HttpVersion.Version11;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(arr, 0, arr.Length);
                dataStream.Close();
                response = (HttpWebResponse)request.GetResponse();

            }
            catch (WebException exc)
            {
                response = (HttpWebResponse)exc.Response;

            }
            if (response != null)
            {
                // we will read data via the response stream
                Stream resStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(
                                              resStream,
                                              Encoding.GetEncoding(response.CharacterSet)
                                            );
                result = streamReader.ReadToEnd();
            }


            return result;
        }
    }

    public abstract class ResponseResult
    {
        public abstract string GetContent();

        public static ResponseResult Text(HttpWebResponse httpWebResponse)
        {
            return new TextResult(httpWebResponse);
        }
    }

    public class TextResult : ResponseResult
    {
        private readonly HttpWebResponse _response;
        private string content;
        public TextResult(HttpWebResponse response)
        {
            _response = response;
        }

        public override string GetContent()
        {
            if (content == null)
            {
                ReadContent();
            }
            return content;
        }

        private void ReadContent()
        {
            Encoding encoding = string.IsNullOrEmpty(_response.ContentEncoding) ? Encoding.UTF8 : Encoding.GetEncoding(_response.ContentEncoding);

            using (StreamReader reader = new StreamReader(_response.GetResponseStream(), encoding))
            {
                content = reader.ReadToEnd();
            }
        }
    }

    public abstract class Content
    {
        public abstract byte[] GetContent();

        public static Content Text(string content)
        {
            return new TextContent(content);
        }

        public static Content File(string file)
        {
            return new FileContent(file);
        }
    }

    public class FileContent : Content
    {
        private readonly string _file;

        public FileContent(string file)
        {
            _file = file;
        }

        public override byte[] GetContent()
        {
            return System.IO.File.ReadAllBytes(_file);
        }
    }

    public class TextContent : Content
    {
        private readonly string _text;


        public TextContent(string text)
        {
            _text = text;
        }

        public override byte[] GetContent()
        {
            return Encoding.UTF8.GetBytes(_text);
        }
    }



    public class HttpRequest
    {

    }
}
