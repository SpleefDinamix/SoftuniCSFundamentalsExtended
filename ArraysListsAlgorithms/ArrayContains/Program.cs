using System;
using System.Linq;


namespace ArrayContains
{
    public class Program
    {
        public static void Main()
        {
            var array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            int numberToFind = int.Parse(Console.ReadLine());

            for (int i = 0; i < array.Length; i++)
            {
                if(array[i] == numberToFind)
                {
                    Console.WriteLine("Yes");
                    break;
                }
                else if(array[i] == array.Length-1)
                {
                    Console.WriteLine("No");
                }
            }
        }
    }
}
