using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptopalsShared
{
    public class XorHelper
    {
        public static byte[] Xor(byte[] byte1, byte[] byte2)
        {
            var byte1Len = byte1.Length;
            if (byte1Len != byte2.Length)
            {
                throw new InvalidOperationException($"Unequal Sized byte arrays: {byte1} and {byte2}");
            }

            var xorArray = new byte[byte1Len];
            for (var i = 0; i < byte1Len; i++)
            {
                xorArray[i] = (byte)(byte1[i] ^ byte2[i]);
            }

            return xorArray;
        }

        public static string XorDecrypt(byte[] byteArray)
        {
            var hex = ByteHelper.HexFromByteArray(byteArray);
            var dict = new SortedDictionary<long, List<string>>();
            var hexKey = string.Empty;
            var j = 0;

            while (hexKey != "FF")
            {
                hexKey = (++j).ToString("X2");
                var tryMe = DictionaryHelper.GenerateRepeatingKey(hexKey, hex.Length);
                var output = Xor(HexHelper.HexToBytes(hex), HexHelper.HexToBytes(tryMe));
                var stringOutput = Encoding.UTF8.GetString(output);
                var score = DictionaryHelper.Score(stringOutput);

                if (dict.ContainsKey(score))
                {
                    dict[score].Add(stringOutput);
                }
                else
                {
                    dict.Add(score, new List<string> { stringOutput });
                }
            }

            return dict.First(kv => kv.Key == dict.Keys.Max()).Value[0];
        }

        public static string XorEncrypt(string plainTextMessage, string plainTextKey)
        {
            var hexMessage = StringHelper.StringToHex(plainTextMessage);
            var encryptionKey = DictionaryHelper.GenerateRepeatingKey(StringHelper.StringToHex(plainTextKey), hexMessage.Length);
            return ByteHelper.HexFromByteArray(Xor(HexHelper.HexToBytes(encryptionKey), HexHelper.HexToBytes(hexMessage)));
        }
    }
}