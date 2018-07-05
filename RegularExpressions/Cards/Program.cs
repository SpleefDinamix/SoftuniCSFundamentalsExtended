using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Cards
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Regex validator = new Regex(@"(?:(?:(?:(?<![0-9])[2-9])|10)|[JQKA])[SHDC]");
            var matches = validator.Matches(input);

            var result = new List<string>();
            foreach (Match match in matches)
            {
                result.Add(match.Value);
            }
            Console.WriteLine(String.Join(", ",result));

        }
    }
}
