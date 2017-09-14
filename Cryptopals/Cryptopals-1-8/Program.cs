using System;
using System.IO;

namespace Cryptopals_1_8
{
    using CryptopalsShared;

    public class Program
    {
        public static void Main(string[] args)
        {
            var path = Path.GetFullPath(Path.Combine(@"Data", @"..\..\..\"));
            path = Path.GetFullPath(Path.Combine(path, "Data/8.txt"));

            var ecbEncryptedString = EcbHelper.TryFindEcbEncryptedString(File.ReadAllLines(path));

            Console.WriteLine(ecbEncryptedString);
            Console.ReadKey();
        }
    }
}
