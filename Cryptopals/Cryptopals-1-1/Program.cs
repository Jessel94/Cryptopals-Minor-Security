using System;

namespace Cryptopals_1_1
{
    internal class Program
    {
        private const string HexString = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d";

        public static void Main(string[] args)
        {
            var data = ConvertFromStringToHex(HexString);
            var base64 = Convert.ToBase64String(data);

            Console.WriteLine(base64);
            Console.ReadKey();
        }

        public static byte[] ConvertFromStringToHex(string inputHex)
        {
            inputHex = inputHex.Replace("-", string.Empty);

            var resultantArray = new byte[inputHex.Length / 2];
            for (var i = 0; i < resultantArray.Length; i++)
            {
                resultantArray[i] = Convert.ToByte(inputHex.Substring(i * 2, 2), 16);
            }

            return resultantArray;
        }
    }
}
