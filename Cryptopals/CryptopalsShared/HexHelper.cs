using System;

namespace CryptopalsShared
{
    public class HexHelper
    {
        public static byte[] ConvertFromStringToHex(string inputHexString)
        {
            // Not needed as the input string does not have dashes as dividers but keeping it in to catch future issues.
            inputHexString = inputHexString.Replace("-", string.Empty);

            // Setup a byte array to store the 8-bit integers based on half the length of the input string.
            var resultantArray = new byte[inputHexString.Length / 2];

            // Based on the input length itterate through the string and turn each set of 2 numbers into a specified base to an equivalent 8-bit unsigned integer.
            for (var i = 0; i < resultantArray.Length; i++)
            {
                resultantArray[i] = Convert.ToByte(inputHexString.Substring(i * 2, 2), 16);
            }

            return resultantArray;
        }
    }
}