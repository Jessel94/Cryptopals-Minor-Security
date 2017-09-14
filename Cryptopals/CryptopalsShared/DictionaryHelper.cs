using System.Linq;
using System.Text;

namespace CryptopalsShared
{
    public class DictionaryHelper
    {
        public static string GenerateRepeatingKey(string hexKey, long targetLength)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < targetLength; i++)
            {
                sb.Append(hexKey[i % hexKey.Length]);
            }
            return sb.ToString();
        }

        public static long Score(string plainText)
        {
            var validChars =
                plainText.Where(c => (
                    c == ' ' || c == ',' ||
                    c == '\n' || c == '\'' ||
                    (c >= 'a' && c <= 'z') ||
                    (c >= 'A' && c <= 'Z'))).LongCount();
            return validChars;
        }
    }
}