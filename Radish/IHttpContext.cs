using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace Radish
{
    public interface IHttpContext
    {
        IHttpRequest Request { get; }
        IHttpResponse Response { get; }
    }

    public interface IHttpResponse
    {
        // Summary:
        //     Gets or sets the System.Text.Encoding for this response's System.Net.HttpListenerResponse.OutputStream.
        //
        // Returns:
        //     An System.Text.Encoding object suitable for use with the data in the System.Net.HttpListenerResponse.OutputStream
        //     property, or null if no encoding is specified.
        Encoding ContentEncoding { get; set; }
        //
        // Summary:
        //     Gets or sets the number of bytes in the body data included in the response.
        //
        // Returns:
        //     The value of the response's Content-Length header.
        //
        // Exceptions:
        //   System.ArgumentOutOfRangeException:
        //     The value specified for a set operation is less than zero.
        //
        //   System.InvalidOperationException:
        //     The response is already being sent.
        //
        //   System.ObjectDisposedException:
        //     This object is closed.
        long ContentLength64 { get; set; }
        //
        // Summary:
        //     Gets or sets the MIME type of the content returned.
        //
        // Returns:
        //     A System.String instance that contains the text of the response's Content-Type
        //     header.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     The value specified for a set operation is null.
        //
        //   System.ArgumentException:
        //     The value specified for a set operation is an empty string ("").
        //
        //   System.ObjectDisposedException:
        //     This object is closed.
        string ContentType { get; set; }
        //
        // Summary:
        //     Gets or sets the collection of cookies returned with the response.
        //
        // Returns:
        //     A System.Net.CookieCollection that contains cookies to accompany the response.
        //     The collection is empty if no cookies have been added to the response.
        CookieCollection Cookies { get; set; }
        //
        // Summary:
        //     Gets or sets the collection of header name/value pairs returned by the server.
        //
        // Returns:
        //     A System.Net.WebHeaderCollection instance that contains all the explicitly
        //     set HTTP headers to be included in the response.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     The System.Net.WebHeaderCollection instance specified for a set operation
        //     is not valid for a response.
        WebHeaderCollection Headers { get; set; }
        //
        // Summary:
        //     Gets or sets a value indicating whether the server requests a persistent
        //     connection.
        //
        // Returns:
        //     true if the server requests a persistent connection; otherwise, false. The
        //     default is true.
        //
        // Exceptions:
        //   System.ObjectDisposedException:
        //     This object is closed.
        bool KeepAlive { get; set; }
        //
        // Summary:
        //     Gets a System.IO.Stream object to which a response can be written.
        //
        // Returns:
        //     A System.IO.Stream object to which a response can be written.
        //
        // Exceptions:
        //   System.ObjectDisposedException:
        //     This object is closed.
        Stream OutputStream { get; }
        //
        // Summary:
        //     Gets or sets the HTTP version used for the response.
        //
        // Returns:
        //     A System.Version object indicating the version of HTTP used when responding
        //     to the client. Note that this property is now obsolete.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     The value specified for a set operation is null.
        //
        //   System.ArgumentException:
        //     The value specified for a set operation does not have its System.Version.Major
        //     property set to 1 or does not have its System.Version.Minor property set
        //     to either 0 or 1.
        //
        //   System.ObjectDisposedException:
        //     This object is closed.
        Version ProtocolVersion { get; set; }
        //
        // Summary:
        //     Gets or sets the value of the HTTP Location header in this response.
        //
        // Returns:
        //     A System.String that contains the absolute URL to be sent to the client in
        //     the Location header.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The value specified for a set operation is an empty string ("").
        //
        //   System.ObjectDisposedException:
        //     This object is closed.
        string RedirectLocation { get; set; }
        //
        // Summary:
        //     Gets or sets whether the response uses chunked transfer encoding.
        //
        // Returns:
        //     true if the response is set to use chunked transfer encoding; otherwise,
        //     false. The default is false.
        bool SendChunked { get; set; }
        //
        // Summary:
        //     Gets or sets the HTTP status code to be returned to the client.
        //
        // Returns:
        //     An System.Int32 value that specifies the HTTP status code for the requested
        //     resource. The default is System.Net.HttpStatusCode.OK, indicating that the
        //     server successfully processed the client's request and included the requested
        //     resource in the response body.
        //
        // Exceptions:
        //   System.ObjectDisposedException:
        //     This object is closed.
        //
        //   System.Net.ProtocolViolationException:
        //     The value specified for a set operation is not valid. Valid values are between
        //     100 and 999 inclusive.
        int StatusCode { get; set; }
        //
        // Summary:
        //     Gets or sets a text description of the HTTP status code returned to the client.
        //
        // Returns:
        //     The text description of the HTTP status code returned to the client. The
        //     default is the RFC 2616 description for the System.Net.HttpListenerResponse.StatusCode
        //     property value, or an empty string ("") if an RFC 2616 description does not
        //     exist.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     The value specified for a set operation is null.
        //
        //   System.ArgumentException:
        //     The value specified for a set operation contains non-printable characters.
        string StatusDescription { get; set; }

        // Summary:
        //     Closes the connection to the client without sending a response.
        void Abort();
        //
        // Summary:
        //     Adds the specified header and value to the HTTP headers for this response.
        //
        // Parameters:
        //   name:
        //     The name of the HTTP header to set.
        //
        //   value:
        //     The value for the name header.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     name is null or an empty string ("").
        //
        //   System.ArgumentException:
        //     You are not allowed to specify a value for the specified header.-or-name
        //     or value contains invalid characters.
        //
        //   System.ArgumentOutOfRangeException:
        //     The length of value is greater than 65,535 characters.
        void AddHeader(string name, string value);
        //
        // Summary:
        //     Adds the specified System.Net.Cookie to the collection of cookies for this
        //     response.
        //
        // Parameters:
        //   cookie:
        //     The System.Net.Cookie to add to the collection to be sent with this response
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     cookie is null.
        void AppendCookie(Cookie cookie);
        //
        // Summary:
        //     Appends a value to the specified HTTP header to be sent with this response.
        //
        // Parameters:
        //   name:
        //     The name of the HTTP header to append value to.
        //
        //   value:
        //     The value to append to the name header.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     name is null or an empty string ("").-or-You are not allowed to specify a
        //     value for the specified header.-or-name or value contains invalid characters.
        //
        //   System.ArgumentOutOfRangeException:
        //     The length of value is greater than 65,535 characters.
        void AppendHeader(string name, string value);
        //
        // Summary:
        //     Sends the response to the client and releases the resources held by this
        //     System.Net.HttpListenerResponse instance.
        void Close();
        //
        // Summary:
        //     Returns the specified byte array to the client and releases the resources
        //     held by this System.Net.HttpListenerResponse instance.
        //
        // Parameters:
        //   responseEntity:
        //     A System.Byte array that contains the response to send to the client.
        //
        //   willBlock:
        //     true to block execution while flushing the stream to the client; otherwise,
        //     false.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     responseEntity is null.
        //
        //   System.ObjectDisposedException:
        //     This object is closed.
        void Close(byte[] responseEntity, bool willBlock);

        //
        // Summary:
        //     Configures the response to redirect the client to the specified URL.
        //
        // Parameters:
        //   url:
        //     The URL that the client should use to locate the requested resource.
        void Redirect(string url);
        //
        // Summary:
        //     Adds or updates a System.Net.Cookie in the collection of cookies sent with
        //     this response.
        //
        // Parameters:
        //   cookie:
        //     A System.Net.Cookie for this response.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     cookie is null.
        //
        //   System.ArgumentException:
        //     The cookie already exists in the collection and could not be replaced.
        void SetCookie(Cookie cookie);
    }

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
        Uri Url { get; }
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
