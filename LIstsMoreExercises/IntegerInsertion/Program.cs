using System;
using System.Linq;

namespace IntegerInsertion
{
    public class Program
    {
        public static void Main()
        {
            var list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            while (input != "end")
            {
                list.Insert(input[0]-48,int.Parse(input)); 
                input = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ",list));
        }
    }
}
