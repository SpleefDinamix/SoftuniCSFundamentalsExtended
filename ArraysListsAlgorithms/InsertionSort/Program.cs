using System;
using System.Linq;

namespace InsertionSort
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Length-1; i++)
            {
                int j = i + 1;

                while (j > 0)
                {
                    int temp = numbers[j];
                    numbers[j] = numbers[j-1];
                    numbers[j-1] = temp;
                    j--;
                }
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
