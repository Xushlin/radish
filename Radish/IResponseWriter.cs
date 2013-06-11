namespace Radish
{
    public interface IResponseWriter
    {
        void Write(IHttpResponse response);
    }
}
