using System;
using System.Text;

namespace CryptopalsShared
{
    public class ByteHelper
    {
        public static string StringFromByteArray(byte[] byteArray)
        {
            var str = new StringBuilder();
            foreach (var byteVal in byteArray)
            {
                str.Append(byteVal.ToString("x2"));
            }

            return str.ToString();
        }
    }
}