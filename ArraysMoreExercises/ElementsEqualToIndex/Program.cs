using System;
using System.Linq;

namespace ElementsEqualToIndex
{
    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            string result = String.Empty;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == i)
                {
                    result += numbers[i] + " ";
                }
            }

            Console.WriteLine(result);

        }
    }
}
