namespace Radish
{
    public interface IResource
    {
        byte[] ToByteArray();
        ResourceType Type { get; }
    }

    public enum ResourceType
    {
        Uri,
        HttpMethod,
        Text
    }
}
