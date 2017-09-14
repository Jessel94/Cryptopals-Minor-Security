using System;
using System.Text;

namespace CryptopalsShared
{
    public class Base64Helper
    {
        public static string Base64ToHex(string base64)
        {
            var sb = new StringBuilder();
            foreach (var b in Convert.FromBase64String(base64))
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}