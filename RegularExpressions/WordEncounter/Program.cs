using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordEncounter
{
    public class Program
    {
        public static void Main()
        {
            var wordAndTimes = Console.ReadLine();
            var sentence = Console.ReadLine();
            var sentenceValidator = new Regex(@"^[A-Z].*[.!?]$");

            string rule = @"\w+";
            var wordValidator = new Regex(rule);
            var wordValues = new List<string>();

            while (sentence != "end")
            {
                if (sentenceValidator.IsMatch(sentence))
                {
                    var wordMatches = wordValidator.Matches(sentence);

                    foreach (Match word in wordMatches)
                    {
                        int count = 0;
                        foreach (var character in word.Value)
                        {
                            if (character == wordAndTimes[0])
                            {
                                count++;
                            }
                        }

                        if (count >= int.Parse(wordAndTimes[1].ToString()))
                        {
                            wordValues.Add(word.Value);
                        }
                    }
                }
                sentence = Console.ReadLine();
            }

            Console.WriteLine(String.Join(", ", wordValues));
        }
    }
}
