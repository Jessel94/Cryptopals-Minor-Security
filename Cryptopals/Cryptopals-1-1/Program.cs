using System;

namespace Cryptopals_1_1
{
    internal class Program
    {
        // Set the string you wish to convert to Base64
        private const string HexString = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d";

        public static void Main(string[] args)
        {
            // Take the set string and convert it to Hex so it can properly be turned into a Base64
            var data = ConvertFromStringToHex(HexString);

            // Converts an array of 8-bit unsigned integers to its equivalent string representation that is encoded with base-64 digits.
            var base64 = Convert.ToBase64String(data);

            // Print the result and wait for a key press to prevent it shutting down right away.
            Console.WriteLine(base64);
            Console.ReadKey();
        }

        public static byte[] ConvertFromStringToHex(string inputHexString)
        {
            // Not needed as the input string does not have dashes as dividers.
            // inputHexString = inputHexString.Replace("-", string.Empty);

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
