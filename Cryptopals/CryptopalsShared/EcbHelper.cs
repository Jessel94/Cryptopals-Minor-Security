namespace CryptopalsShared
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;

    public class EcbHelper
    {
        public static byte[] EcbAesDecrypt(byte[] encryptedMessage, byte[] key, byte[] iv)
        {
            var aes = new AesManaged
                          {
                              KeySize = 128,
                              Key = key,
                              Mode = CipherMode.ECB,
                              IV = iv,
                              Padding = PaddingMode.None
                          };

            var ict = aes.CreateDecryptor();
            return ict.TransformFinalBlock(encryptedMessage, 0, encryptedMessage.Length);
        }

        public static string TryFindEcbEncryptedString(IEnumerable<string> base64EncodedString)
        {
            var repetitions = new Dictionary<string, int>();
            foreach (var base64Encoded in base64EncodedString)
            {
                var hex = Base64Helper.Base64ToHex(base64Encoded);
                var dictionary = new Dictionary<string, int>();

                for (var i = 0; i < hex.Length / 32; i++)
                {
                    var bytes16 = hex.Substring(i * 32, 32);
                    if (dictionary.ContainsKey(bytes16))
                    {
                        dictionary[bytes16]++;
                    }
                    else
                    {
                        dictionary.Add(hex.Substring(i * 32, 32), 1);
                    }
                }
                repetitions.Add(base64Encoded, dictionary.Keys.Count);
            }

            return repetitions.First(kv => kv.Value == repetitions.Values.Min()).Key;
        }
    }
}