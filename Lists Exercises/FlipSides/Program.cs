using System;
using System.Linq;

namespace FlipSides
{
    public class Program
    {
        public static void Main()
        {
            var list = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            
            list.Reverse();
            int temp = list[0];
            list[0] = list[list.Count-1];
            list[list.Count - 1] = temp;

            Console.WriteLine(String.Join(" ",list));

        }
    }
}
