using System;

namespace CountNegatives
{
    public class Program
    {
        public static void Main()
        {
            int times = int.Parse(Console.ReadLine());
            int[] numbers = new int[times];

            for (int i = 0; i < times; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int negativeCount = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    negativeCount++;
                }
            }

            Console.WriteLine(negativeCount);

        }
    }
}
