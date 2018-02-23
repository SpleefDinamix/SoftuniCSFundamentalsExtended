using System;
using System.Linq;


namespace ManyBiggerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
             double[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            double p = double.Parse(Console.ReadLine());
            int count = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i]>p)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
