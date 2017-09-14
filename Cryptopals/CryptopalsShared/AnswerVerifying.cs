namespace CryptopalsShared
{
    using System;

    public class AnswerVerifying
    {
        public static void Verify(string expectedAnswer, string result)
        {
            Console.WriteLine(result);
            if (result.Equals(expectedAnswer))
            {
                Console.WriteLine("The answer is Correct!");
            }

            Console.ReadKey();
        }
    }
}