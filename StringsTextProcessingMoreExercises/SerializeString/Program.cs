using System;
using System.Collections.Generic;
using System.Linq;

namespace SerializeString
{
    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            char[] uniqueChars = text.Distinct().ToArray();

            var counter = new Dictionary<char, List<int>>();
            Array.ForEach(uniqueChars, x => counter[x] = new List<int>());

            //Find all matching indexes and store them in the dictionary
            foreach (var uChar in uniqueChars)
            {
                int lastIndex = text.IndexOf(uChar);
                counter[uChar].Add(lastIndex);

                while (true)
                {
                    int nextIndex = text.IndexOf(uChar, lastIndex + 1);
                    if (nextIndex < 0)
                    {
                        break;
                    }
                    counter[uChar].Add(nextIndex);
                    lastIndex = nextIndex;
                }
            }

            //Printing chars with all indexes found in text 
            counter
                .ToList()
                .ForEach(x => Console.WriteLine(
                    x.Key + ":" + String.Join("/",x.Value)));
        }
    }
}
