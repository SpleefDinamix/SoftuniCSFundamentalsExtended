using System;
using System.Collections.Generic;

namespace LetterRepetition
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            var counter = new Dictionary<char,int>();

            foreach (var letter in input)
            {
                if (!counter.ContainsKey(letter))
                {
                    counter.Add(letter,0);
                }
                counter[letter]++;
            }

            foreach (KeyValuePair<char,int> pair in counter)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }

        }
    }
}
