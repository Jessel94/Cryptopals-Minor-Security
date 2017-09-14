using System;
using CryptopalsShared;

namespace Cryptopals_1_1
{
    internal class Program
    {
        private const string HexString = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d";
        private const string ExpectedAnswer = "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t";

        public static void Main(string[] args)
        {
            var data = HexHelper.HexToBytes(HexString);
            var base64 = Convert.ToBase64String(data);

            Console.WriteLine(base64);
            if (base64.Equals(ExpectedAnswer))
            {
                Console.WriteLine("The answer is Correct!");
            }

            Console.ReadKey();
        }
    }
}
