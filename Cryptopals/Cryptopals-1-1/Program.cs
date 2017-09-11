using System;
using CryptopalsShared;

namespace Cryptopals_1_1
{
    internal class Program
    {
        // Set the string you wish to convert to Base64
        private const string HexString = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d";
        private const string ExpectedAnswer = "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t";

        public static void Main(string[] args)
        {
            // Take the set string and convert it to Hex so it can properly be turned into a Base64
            var data = HexHelper.ConvertFromStringToHex(HexString);

            // Converts an array of 8-bit unsigned integers to its equivalent string representation that is encoded with base-64 digits.
            var base64 = Convert.ToBase64String(data);

            // Print the result and wait for a key press to prevent it shutting down right away.
            Console.WriteLine(base64);

            if (base64.Equals(ExpectedAnswer))
            {
                Console.WriteLine("The answer is Correct!");
            }

            Console.ReadKey();
        }
    }
}
