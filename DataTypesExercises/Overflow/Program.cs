using System;

namespace Overflow
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            int times = 0;
            byte variable = 0;

            for (int i=0; i < n; i++)
            {
                variable++;
                if (variable == 0)
                {
                    times++;
                }
            }
            Console.WriteLine(variable);
            Console.WriteLine($"Overflowed {times} times");
        }
    }
}
