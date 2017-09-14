namespace CryptopalsShared
{
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
    }
}