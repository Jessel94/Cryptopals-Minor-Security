using System.Text;

namespace CryptopalsShared
{
    public class StringHelper
    {
        public static string StringToHex(string s)
        {
            var sb = new StringBuilder();
            foreach (var c in s)
            {
                sb.Append(((byte)c).ToString("X2"));
            }
            return sb.ToString();
        }
    }
}