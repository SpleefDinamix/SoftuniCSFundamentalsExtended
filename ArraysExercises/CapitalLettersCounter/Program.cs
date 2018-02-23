using System;
using System.Linq;

namespace CapitalLettersCounter
{
    class Program
    {
        static void Main()
        {
            string[] words = Console.ReadLine()
                .Split(' ')
                .ToArray();

            int counter = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == 1)
                {
                    char currentLetter = char.Parse(words[i]);

                    if (currentLetter >= 65 && currentLetter <= 90)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);

        }
    }
}
