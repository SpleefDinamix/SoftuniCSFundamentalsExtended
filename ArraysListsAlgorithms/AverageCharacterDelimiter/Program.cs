using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageCharacterDelimiter
{
    public class Program
    {
        public static void Main()
        {
            var strings = Console.ReadLine().Split().ToList();
            int average = FindListAverage(strings);

            string delimiter = $"{((char)average).ToString().ToUpper()}";
            Console.WriteLine(String.Join(delimiter, strings));
        }

        public static int FindListAverage(List<string> strings)
        {
            int sum = 0;
            int itemCount = 0;

            foreach (var stringy in strings)
            {
                foreach (var letter in stringy)
                {
                    sum += letter;
                    itemCount++;
                }
            }

            int average = sum / itemCount;

            return average;
        }

    }
}
