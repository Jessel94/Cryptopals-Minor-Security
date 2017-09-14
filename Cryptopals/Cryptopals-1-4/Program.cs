using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptopals_1_4
{
    using System.IO;

    using CryptopalsShared;

    public class Program
    {
        private const string ExpectedAnswer = "Now that the party is jumping\n";

        public static void Main(string[] args)
        {
            var path = Path.GetFullPath(Path.Combine(@"Data", @"..\..\..\"));
            path = Path.GetFullPath(Path.Combine(path, "Data/4.txt"));

            var decryptedMessages = new Dictionary<string, long>();
            File.ReadAllLines(path)
                .ToList()
                .ForEach(item =>
                    {
                        var d = XorHelper.XorDecrypt(HexHelper.HexToBytes(item));
                        decryptedMessages.Add(d, DictionaryHelper.Score(d));
                    });
            var decryptedMessage = decryptedMessages.First(kv => kv.Value == decryptedMessages.Values.Max()).Key;

            Console.WriteLine(decryptedMessage);
            if (decryptedMessage.Equals(ExpectedAnswer))
            {
                Console.WriteLine("The answer is Correct!");
            }

            Console.ReadKey();
        }
    }
}
