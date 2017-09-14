using System;

namespace CryptopalsShared
{
    public class HexHelper
    {
        public static byte[] HexToBytes(string inputHexString)
        {
            inputHexString = inputHexString.Replace("-", string.Empty);
            var resultantArray = new byte[inputHexString.Length / 2];

            for (var i = 0; i < resultantArray.Length; i++)
            {
                resultantArray[i] = Convert.ToByte(inputHexString.Substring(i * 2, 2), 16);
            }

            return resultantArray;
        }
    }
}