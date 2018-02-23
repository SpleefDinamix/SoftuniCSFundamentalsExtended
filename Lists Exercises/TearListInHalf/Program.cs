using System;
using System.Linq;
using System.Collections.Generic;

namespace TearListInHalf
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var output = new List<int>();
            for (int i = input.Count / 2; i < input.Count; i++)
            {
                int digit2 = input[i] % 10;
                int digit1 = input[i] / 10;

                    output.Add(digit1);
                    output.Add(input[i - input.Count / 2]);
                    output.Add(digit2);

            }

            Console.WriteLine(String.Join(" ", output));
            Console.ReadLine();

        }
    }
}
