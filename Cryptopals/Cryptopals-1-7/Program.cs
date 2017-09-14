using System;
using System.IO;
using System.Text;

using CryptopalsShared;

namespace Cryptopals_1_7
{
    public class Program
    {
        private const string AesKey = "YELLOW SUBMARINE";

        public static void Main(string[] args)
        {
            var path = Path.GetFullPath(Path.Combine(@"Data", @"..\..\..\"));
            path = Path.GetFullPath(Path.Combine(path, "Data/7.txt"));

            var base64Encoded = File.ReadAllText(path);
            var decryptedEcb = EcbHelper.EcbAesDecrypt(
                Convert.FromBase64String(base64Encoded),
                Encoding.UTF8.GetBytes(AesKey),
                new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

            var output = Encoding.ASCII.GetString(decryptedEcb);

            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
