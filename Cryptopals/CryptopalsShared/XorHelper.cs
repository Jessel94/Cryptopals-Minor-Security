using System;

namespace CryptopalsShared
{
    public class XorHelper
    {
        public static byte[] Xor2HexArrays(byte[] byte1, byte[] byte2)
        {
            var byte1Len = byte1.Length;
            if (byte1Len != byte2.Length)
            {
                throw new InvalidOperationException($"Unequal byte arrays: {byte1} and {byte2}");
            }

            var xorArray = new byte[byte1Len];
            for (var i = 0; i < byte1Len; i++)
            {
                xorArray[i] = (byte)(byte1[i] ^ byte2[i]);
            }

            return xorArray;
        }
    }
}