using System;
using CryptopalsShared;

namespace Cryptopals_1_3
{
    internal class Program
    {
        private const string HexString = "1b37373331363f78151b7f2b783431333d78397828372d363c78373e783a393b3736";
        private const string ExpectedAnswer = "Cooking MC's like a pound of bacon";

        public static void Main(string[] args)
        {
            var data = HexHelper.HexToBytes(HexString);
            var decryptedMessage1 = XorHelper.XorDecrypt(data);

            Console.WriteLine(decryptedMessage1);
            if (decryptedMessage1.Equals(ExpectedAnswer))
            {
                Console.WriteLine("The answer is Correct!");
            }

            Console.ReadKey();
        }
    }
}
