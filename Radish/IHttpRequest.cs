using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace Radish
{
    public interface IHttpRequest
    {
        // Summary:
        //     Gets the MIME types accepted by the client.
        //
        // Returns:
        //     A System.String array that contains the type names specified in the request's
        //     Accept header or null if the client request did not include an Accept header.
        string[] AcceptTypes { get; }
        //
        // Summary:
        //     Gets an error code that identifies a problem with the System.Security.Cryptography.X509Certificates.X509Certificate
        //     provided by the client.
        //
        // Returns:
        //     An System.Int32 value that contains a Windows error code.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     The client certificate has not been initialized yet by a call to the System.Net.HttpListenerRequest.BeginGetClientCertificate(System.AsyncCallback,System.Object)
        //     or System.Net.HttpListenerRequest.GetClientCertificate() methods-or - The
        //     operation is still in progress.
        int ClientCertificateError { get; }
        //
        // Summary:
        //     Gets the content encoding that can be used with data sent with the request
        //
        // Returns:
        //     An System.Text.Encoding object suitable for use with the data in the System.Net.HttpListenerRequest.InputStream
        //     property.
        Encoding ContentEncoding { get; }
        //
        // Summary:
        //     Gets the length of the body data included in the request.
        //
        // Returns:
        //     The value from the request's Content-Length header. This value is -1 if the
        //     content length is not known.
        long ContentLength64 { get; }
        //
        // Summary:
        //     Gets the MIME type of the body data included in the request.
        //
        // Returns:
        //     A System.String that contains the text of the request's Content-Type header.
        string ContentType { get; }
        //
        // Summary:
        //     Gets the cookies sent with the request.
        //
        // Returns:
        //     A System.Net.CookieCollection that contains cookies that accompany the request.
        //     This property returns an empty collection if the request does not contain
        //     cookies.
        CookieCollection Cookies { get; }
        //
        // Summary:
        //     Gets a System.Boolean value that indicates whether the request has associated
        //     body data.
        //
        // Returns:
        //     true if the request has associated body data; otherwise, false.
        bool HasEntityBody { get; }
        //
        // Summary:
        //     Gets the collection of header name/value pairs sent in the request.
        //
        // Returns:
        //     A System.Net.WebHeaderCollection that contains the HTTP headers included
        //     in the request.
        NameValueCollection Headers { get; }
        //
        // Summary:
        //     Gets the HTTP method specified by the client.
        //
        // Returns:
        //     A System.String that contains the method used in the request.
        string HttpMethod { get; }
        //
        // Summary:
        //     Gets a stream that contains the body data sent by the client.
        //
        // Returns:
        //     A readable System.IO.Stream object that contains the bytes sent by the client
        //     in the body of the request. This property returns System.IO.Stream.Null if
        //     no data is sent with the request.
        Stream InputStream { get; }
        //
        // Summary:
        //     Gets a System.Boolean value that indicates whether the client sending this
        //     request is authenticated.
        //
        // Returns:
        //     true if the client was authenticated; otherwise, false.
        bool IsAuthenticated { get; }
        //
        // Summary:
        //     Gets a System.Boolean value that indicates whether the request is sent from
        //     the local computer.
        //
        // Returns:
        //     true if the request originated on the same computer as the System.Net.HttpListener
        //     object that provided the request; otherwise, false.
        bool IsLocal { get; }
        //
        // Summary:
        //     Gets a System.Boolean value that indicates whether the TCP connection used
        //     to send the request is using the Secure Sockets Layer (SSL) protocol.
        //
        // Returns:
        //     true if the TCP connection is using SSL; otherwise, false.
        bool IsSecureConnection { get; }
        //
        // Summary:
        //     Gets a System.Boolean value that indicates whether the client requests a
        //     persistent connection.
        //
        // Returns:
        //     true if the connection should be kept open; otherwise, false.
        bool KeepAlive { get; }
        //
        // Summary:
        //     Get the server IP address and port number to which the request is directed.
        //
        // Returns:
        //     An System.Net.IPEndPoint that represents the IP address that the request
        //     is sent to.
        IPEndPoint LocalEndPoint { get; }
        //
        // Summary:
        //     Gets the HTTP version used by the requesting client.
        //
        // Returns:
        //     A System.Version that identifies the client's version of HTTP.
        Version ProtocolVersion { get; }
        //
        // Summary:
        //     Gets the query string included in the request.
        //
        // Returns:
        //     A System.Collections.Specialized.NameValueCollection object that contains
        //     the query data included in the request System.Net.HttpListenerRequest.Url.
        NameValueCollection QueryString { get; }
        //
        // Summary:
        //     Gets the URL information (without the host and port) requested by the client.
        //
        // Returns:
        //     A System.String that contains the raw URL for this request.
        string RawUrl { get; }
        //
        // Summary:
        //     Gets the client IP address and port number from which the request originated.
        //
        // Returns:
        //     An System.Net.IPEndPoint that represents the IP address and port number from
        //     which the request originated.
        IPEndPoint RemoteEndPoint { get; }
        //
        // Summary:
        //     Gets the request identifier of the incoming HTTP request.
        //
        // Returns:
        //     A System.Guid object that contains the identifier of the HTTP request.
        Guid RequestTraceIdentifier { get; }
        //
        // Summary:
        //     Gets the Service Provider Name (SPN) that the client sent on the request.
        //
        // Returns:
        //     A System.String that contains the SPN the client sent on the request.
        string ServiceName { get; }
        //
        // Summary:
        //     Gets the System.Net.TransportContext for the client request.
        //
        // Returns:
        //     A System.Net.TransportContext object for the client request.
        TransportContext TransportContext { get; }
        //
        // Summary:
        //     Gets the System.Uri object requested by the client.
        //
        // Returns:
        //     A System.Uri object that identifies the resource requested by the client.
        Uri Url { get;  }
        //
        // Summary:
        //     Gets the Uniform Resource Identifier (URI) of the resource that referred
        //     the client to the server.
        //
        // Returns:
        //     A System.Uri object that contains the text of the request's System.Net.HttpRequestHeader.Referer
        //     header, or null if the header was not included in the request.
        Uri UrlReferrer { get; }
        //
        // Summary:
        //     Gets the user agent presented by the client.
        //
        // Returns:
        //     A System.String object that contains the text of the request's User-Agent
        //     header.
        string UserAgent { get; }
        //
        // Summary:
        //     Gets the server IP address and port number to which the request is directed.
        //
        // Returns:
        //     A System.String that contains the host address information.
        string UserHostAddress { get; }
        //
        // Summary:
        //     Gets the DNS name and, if provided, the port number specified by the client.
        //
        // Returns:
        //     A System.String value that contains the text of the request's Host header.
        string UserHostName { get; }
        //
        // Summary:
        //     Gets the natural languages that are preferred for the response.
        //
        // Returns:
        //     A System.String array that contains the languages specified in the request's
        //     System.Net.HttpRequestHeader.AcceptLanguage header or null if the client
        //     request did not include an System.Net.HttpRequestHeader.AcceptLanguage header.
        string[] UserLanguages { get; }
    }
}
