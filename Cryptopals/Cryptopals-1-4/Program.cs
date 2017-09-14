using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using CryptopalsShared;

namespace Cryptopals_1_4
{
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

            AnswerVerifying.Verify(ExpectedAnswer, decryptedMessage);
        }
    }
}
