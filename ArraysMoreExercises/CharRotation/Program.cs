using System;
using System.Linq;

namespace CharRotation
{
    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string result =  String.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    result += (char)(text[i] - numbers[i]);
                }
                else
                {
                    result += (char)(text[i] + numbers[i]);
                }
                
            }

            Console.WriteLine(result);

        }
    }
}
