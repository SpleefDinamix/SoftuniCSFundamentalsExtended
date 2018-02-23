using System;
using System.Linq;

namespace ReverseArray
{
    public class Program
    {
        public static void Main()
        {
            var array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < array.Length/2; i++)
            {
                int temp = array[i];
                array[i] = array[array.Length-i-1];
                array[array.Length - i - 1] = temp;
            }

            Console.WriteLine(String.Join(" ",array));
        }
    }
}
