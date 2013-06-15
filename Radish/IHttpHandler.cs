namespace Radish
{
    public interface IHttpHandler
    {
        void Handle(IHttpContext context);
    }
}
