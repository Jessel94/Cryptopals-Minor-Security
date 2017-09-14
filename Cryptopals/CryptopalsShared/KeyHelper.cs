using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace CryptopalsShared
{
   public class KeyHelper
    {
        public static string DecipherKey(string base64XorEncrypted)
        {
            var bytes = Convert.FromBase64String(base64XorEncrypted);
            var hex = Base64Helper.Base64ToHex(base64XorEncrypted);

            var scores = new Dictionary<int, double>();
            for (var tryLength = 2; tryLength <= 40; tryLength++)
            {
                var firstBlock = bytes.Take(tryLength).ToArray();
                var secondBlock = bytes.Skip(tryLength).Take(tryLength).ToArray();
                var thirdBlock = bytes.Skip(2 * tryLength).Take(tryLength).ToArray();
                var fourthBlock = bytes.Skip(3 * tryLength).Take(tryLength).ToArray();
                var fifthBlock = bytes.Skip(4 * tryLength).Take(tryLength).ToArray();
                var score = (double)HammingDistance(firstBlock, secondBlock) / tryLength +
                        (double)HammingDistance(firstBlock, thirdBlock) / tryLength +
                        (double)HammingDistance(firstBlock, fourthBlock) / tryLength +
                        (double)HammingDistance(firstBlock, fifthBlock) / tryLength;
                scores.Add(tryLength, score);
            }

            var bestMatchKeyString = string.Empty;
            long bestScore = 0;
            foreach (var item in scores.ToList().OrderBy(pair => pair.Value).Take(3))
            {
                var keySize = item.Key;
                long totalScore = 0;
                var keyString = string.Empty;

                for (var i = 0; i < keySize; i++)
                {
                    var decodeMe = new List<byte>();
                    for (var j = 0; j < bytes.Length / keySize; j++)
                    {
                        decodeMe.Add(bytes[i + j * keySize]);
                    }
                    var decoded = XorHelper.XorDecrypt(decodeMe.ToArray());
                    keyString += (char)(decoded[0] ^ decodeMe[0]);
                    totalScore += DictionaryHelper.Score(XorHelper.XorDecrypt(decodeMe.ToArray()));
                }

                if (totalScore <= bestScore)
                {
                    continue;
                }

                bestScore = totalScore;
                bestMatchKeyString = keyString;
            }

            var key = GenerateRepeatingKey(StringHelper.StringToHex(bestMatchKeyString), hex.Length);
            return Encoding.UTF8.GetString(XorHelper.Xor(HexHelper.HexToBytes(hex), HexHelper.HexToBytes(key)));
        }

        public static int HammingDistance(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
            {
                throw new InvalidDataException("Input strings length should be equal");
            }

            var hammingDistance = 0;
            for (var i = 0; i < a.Length; i++)
            {
                var c = (byte)(a[i] ^ b[i]);
                while (c != 0)
                {
                    if (c % 2 == 1)
                    {
                        hammingDistance++;
                    }

                    c >>= 1;
                }
            }

            return hammingDistance;
        }

        public static string GenerateRepeatingKey(string hexKey, long targetLength)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < targetLength; i++)
            {
                sb.Append(hexKey[i % hexKey.Length]);
            }
            return sb.ToString();
        }
    }
}