using System;

namespace STACK_UP
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintName(Console.ReadLine());
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMin(a,b,c));
        }

        static void PrintName(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }

        static int GetMin(int a, int b, int c)
        {
            return a < b ? a<c? a:c : b<c? b:c;
        }
    }
}
