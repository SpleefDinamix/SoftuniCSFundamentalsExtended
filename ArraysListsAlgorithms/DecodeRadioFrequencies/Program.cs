using System;
using System.Collections.Generic;
using System.Linq;

namespace DecodeRadioFrequencies
{
    public class Program
    {
        public static void Main()
        {
            var frequencies = Console.ReadLine()
                .Split(' ');

            List<char> letters = new List<char>();
            ExtractLettersFromFrequencies(frequencies, letters);

            Console.WriteLine(String.Join("",letters));

        }

        public static void ExtractLettersFromFrequencies(string[] frequencies, List<char> letters)
        {
            for(int i=0; i<frequencies.Length; i++)
            {
                var frequencySplit = frequencies[i]
                    .Split('.')
                    .Select(int.Parse)
                    .ToArray();

                if (frequencySplit.First() != 0)
                {
                    letters.Insert( i ,(char) frequencySplit.First());
                }

                if (frequencySplit.Last() != 0)
                {
                    letters.Insert(letters.Count - i,(char) frequencySplit.Last());
                }

            }
        }
    }
}
