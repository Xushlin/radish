﻿using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace Radish.Adapters
{
    public class HttpListenerRequestAdapter : IHttpRequest
    {
        private readonly HttpListenerRequest _request;

        public HttpListenerRequestAdapter(HttpListenerRequest request)
        {
            _request = request;
        }

        public string[] AcceptTypes { get { return _request.AcceptTypes; } }
        public int ClientCertificateError { get { return _request.ClientCertificateError; } }
        public Encoding ContentEncoding { get { return _request.ContentEncoding; } }
        public long ContentLength64 { get { return _request.ContentLength64; } }
        public string ContentType { get { return _request.ContentType; } }
        public CookieCollection Cookies { get { return _request.Cookies; } }
        public bool HasEntityBody { get { return _request.HasEntityBody; } }
        public NameValueCollection Headers { get { return _request.Headers; } }
        public string HttpMethod { get { return _request.HttpMethod; } }
        public Stream InputStream { get { return _request.InputStream; } }
        public bool IsAuthenticated { get { return _request.IsAuthenticated; } }
        public bool IsLocal { get { return _request.IsLocal; } }
        public bool IsSecureConnection { get { return _request.IsSecureConnection; } }
        public bool KeepAlive { get { return _request.KeepAlive; } }
        public IPEndPoint LocalEndPoint { get { return _request.LocalEndPoint; } }
        public Version ProtocolVersion { get { return _request.ProtocolVersion; } }
        public NameValueCollection QueryString { get { return _request.QueryString; } }
        public string RawUrl { get { return _request.RawUrl; } }
        public IPEndPoint RemoteEndPoint { get { return _request.RemoteEndPoint; } }
        public Guid RequestTraceIdentifier { get { return _request.RequestTraceIdentifier; } }
        public string ServiceName { get { return _request.ServiceName; } }
        public TransportContext TransportContext { get { return _request.TransportContext; } }
        public Uri Url { get { return _request.Url; } }
        public Uri UrlReferrer { get { return _request.UrlReferrer; } }
        public string UserAgent { get { return _request.UserAgent; } }
        public string UserHostAddress { get { return _request.UserHostAddress; } }
        public string UserHostName { get { return _request.UserHostName; } }
        public string[] UserLanguages { get { return _request.UserLanguages; } }
    }
}
