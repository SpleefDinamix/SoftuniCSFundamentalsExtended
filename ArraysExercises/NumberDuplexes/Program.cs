using System;

namespace NumberDuplexes
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string[] parts = Console.ReadLine().Split(' ');
            int[] numbers = new int[parts.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(parts[i]);
            }

            int dublicatedNumber = int.Parse(Console.ReadLine());
            int result = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] == dublicatedNumber)
                {
                    result++;
                }
            }

            Console.WriteLine(result);
        }
    }
}
