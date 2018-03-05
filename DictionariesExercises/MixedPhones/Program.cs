using System;
using System.Collections.Generic;
using System.Linq;

namespace MixedPhones
{
    public class Program
    {
        public static void Main()
        {
            var phoneBook = new SortedDictionary<string,long>();
            var input = Console.ReadLine();

            while (input != "Over")
            {
                var parts = input.Split();
                string dictKey = parts[0];
                long dictValue;
                bool isCorrectOrder = long.TryParse(parts[parts.Length - 1],out dictValue);

                if (!isCorrectOrder)
                {
                    dictValue = long.Parse(dictKey);
                    dictKey = parts[parts.Length - 1];
                }
                
                phoneBook[dictKey] = dictValue;
                input = Console.ReadLine();
            }

            foreach (var kvp in phoneBook)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

        }
    }
}
