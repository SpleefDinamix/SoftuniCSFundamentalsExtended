using System;
using System.Collections.Generic;
using System.Linq;

namespace DefaultValues
{
    public class Program
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var wordDict = new Dictionary<string, string>();

            while (inputLine != "end")
            {
                var parts = inputLine
                    .Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                wordDict[parts.First()] = parts.Last();

                inputLine = Console.ReadLine();
            }

            var defautValue = Console.ReadLine();

            wordDict
                .Where(x => x.Value != "null")
                .OrderByDescending(x => x.Value.Length)
                .ToList()
                .ForEach(x => {
                    Console.WriteLine(x.Key + " <-> " + x.Value);
                });

            wordDict
                .Where(x => x.Value == "null")
                .Select(x => x.Key + " <-> " + defautValue)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
