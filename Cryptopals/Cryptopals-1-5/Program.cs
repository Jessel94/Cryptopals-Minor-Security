﻿using CryptopalsShared;

namespace Cryptopals_1_5
{
    public class Program
    {
        private const string Key = "ICE";
        private const string Message = "Burning 'em, if you ain't quick and nimble\nI go crazy when I hear a cymbal";
        private const string ExpectedAnswer = "0b3637272a2b2e63622c2e69692a23693a2a3c6324202d623d63343c2a26226324272765272a282b2f20430a652e2c652a3124333a653e2b2027630c692b20283165286326302e27282f";

        public static void Main(string[] args)
        {
            var encryptedMessage = XorHelper.XorEncrypt(Message, Key);

            AnswerVerifying.Verify(ExpectedAnswer, encryptedMessage);
        }
    }
}
