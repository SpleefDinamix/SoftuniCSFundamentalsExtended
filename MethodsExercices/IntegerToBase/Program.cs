using System;

namespace IntegerToBase
{
    class Program
    {
        public static void Main()
        {
            long input = long.Parse(Console.ReadLine());
            int theBase = int.Parse(Console.ReadLine());

            var result = IntegerToBase(input, theBase);
            Console.WriteLine(result);
        }

        static string IntegerToBase(long number, int toBase)
        {
            var bin = string.Empty;

            while (number != 0)
            {
                bin = number % toBase + bin;
                number /= toBase;
            }

            return bin;
        }

    }
}
