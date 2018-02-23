using System;
using System.Linq;

namespace NoDuplicates
{
    public class Program
    {
        public static void Main()
        {
            var list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Distinct()
                .ToList();

            Console.WriteLine(String.Join(" ",list));

        }
    }
}
