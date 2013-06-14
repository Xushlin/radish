using System.Text;

namespace Radish.Extensions
{
    public static class StringExtensions
    {
        public static byte[] ToByteArray(this string @string)
        {
            return Encoding.UTF8.GetBytes(@string);
        }
    }
}
