using System;
using System.Linq;

namespace BeepTest
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(char.Parse)
                .ToArray();

            foreach (var item in input)
            {
                Console.Beep(item, 200);
            }
        }
    }
}
