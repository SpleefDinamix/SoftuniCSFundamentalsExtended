using System;

namespace NthNumber
{
    class Program
    {
        static void Main()
        {
            var computedNumber = Console.ReadLine();
            int place = int.Parse(Console.ReadLine());

            int foundIndex = FindNthDigit(computedNumber, place);
            Console.WriteLine(foundIndex);
        }
        static int FindNthDigit(string number, int index)
        {
            return (number[number.Length-index]) - '0';
        }
    }
}
