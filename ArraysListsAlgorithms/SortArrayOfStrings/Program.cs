using System;
using System.Collections.Generic;
using System.Linq;

namespace SortArrayOfStrings
{
    public class Program
    {
        public static void Main()
        {
            var words = Console.ReadLine()
                .Split()
                .ToList();
            
            BubbleSort(words);

            Console.WriteLine(String.Join(" ", words));

        }

        private static void BubbleSort(List<string> words)
        {
            bool swapped = false;

            do
            {
                swapped = false;
                for (int i = 0; i < words.Count - 1; i++)
                {
                    if (words[i].CompareTo(words[i + 1]) > 0)
                    {
                        swapped = true;

                        var temp = words[i];
                        words[i] = words[i + 1];
                        words[i + 1] = temp;
                    }
                }
            } while (swapped);
        }
    }
}
