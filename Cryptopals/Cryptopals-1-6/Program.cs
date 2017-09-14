using System;
using System.IO;

namespace Cryptopals_1_6
{
    using CryptopalsShared;

    public class Program
    {
        public static void Main(string[] args)
        {
            var path = Path.GetFullPath(Path.Combine(@"Data", @"..\..\..\"));
            path = Path.GetFullPath(Path.Combine(path, "Data/6.txt"));

            var pathOut = Path.GetFullPath(Path.Combine(@"Data", @"..\..\..\"));
            pathOut = Path.GetFullPath(Path.Combine(pathOut, "Data/6-out.txt"));

            var xorEncrypted = File.ReadAllText(path);
            var decryptedXor = KeyHelper.DecipherKey(xorEncrypted);
            File.WriteAllText(pathOut, decryptedXor);

            Console.WriteLine(decryptedXor);
            Console.ReadKey();
        }
    }
}
