using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public class Md5Hasher
    {
        public static string GetMd5Hash(string str)
        {
            var md5Hasher = MD5.Create();
            var data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(str));
            var sb = new StringBuilder();
            foreach (var b in data)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

    }
}