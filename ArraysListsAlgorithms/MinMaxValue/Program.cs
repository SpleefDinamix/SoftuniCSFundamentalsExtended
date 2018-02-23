using System;
using System.Collections.Generic;
using System.Linq;

namespace MinMaxValue
{
    public class Program
    {
        public static void Main()
        {
            var array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int minNumber = array[0];
            int maxNumber = array[0];

            foreach (var number in array)
            {
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }

            foreach (var number in array)
            {
                if (number > maxNumber)
                {
                    maxNumber = number;
                }
            }

            Console.WriteLine($"Min:{minNumber}");
            Console.WriteLine($"Max:{maxNumber}");
        }
    }
}
