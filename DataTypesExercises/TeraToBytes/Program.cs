using System;

namespace TeraToBytes
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Eneter a number in Terrabytes:");
            var input = double.Parse(Console.ReadLine());
            Console.WriteLine($"You entered {input}T and converted to {input * 1024 * 1024 * 1024 * 1024 * 8}b");
        }
    }
}
