using System;
using System.Linq;

namespace IncreasingSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string text = String.Empty;

            for (int i = 0; i < numbers.Length-1; i++)
            {
                if(numbers[i + 1] - numbers[i]>0)
                {
                    text = "Yes";
                }
                else
                {
                    text = "No";
                    break;
                }
            }
            Console.WriteLine(text);
        }
    }
}
