using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Fabian.Domurad.Golden.Card.Research.Shared.Extension
{
    public static class StringExtension
    {
        public static string ToHash(this string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            var hashString = new SHA256Managed();
            var hash = hashString.ComputeHash(bytes);
            return hash.Aggregate(string.Empty, (current, x) => current + $"{x:x2}");
        }
    }
}
