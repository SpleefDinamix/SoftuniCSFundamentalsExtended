using System;

namespace SentenceSplit
{
    public class Program
    {
        public static void Main()
        {
            var sentence = Console.ReadLine();
            string delimiter = Console.ReadLine();

            var parts = sentence
                .Split(new[] { delimiter }, StringSplitOptions.None);

            string result = "[" + String.Join(", ", parts) + "]";
            Console.WriteLine(result);
        }
    }
}
