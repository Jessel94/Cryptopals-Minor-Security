using System;
using CryptopalsShared;

namespace Cryptopals_1_2
{
    internal class Program
    {
        private const string ExpectedAnswer = "746865206b696420646f6e277420706c6179";

        public static void Main(string[] args)
        {
            var byteArr1 = HexHelper.ConvertFromStringToHex("1c0111001f010100061a024b53535009181c");
            var byteArr2 = HexHelper.ConvertFromStringToHex("686974207468652062756c6c277320657965");

            var xorValues = XorHelper.Xor2HexArrays(byteArr1, byteArr2);
            var stringVal = ByteHelper.StringFromByteArray(xorValues);

            Console.WriteLine(stringVal);
            if (stringVal.Equals(ExpectedAnswer))
            {
                Console.WriteLine("The answer is Correct!");
            }

            Console.ReadKey();
        }
    }
}
