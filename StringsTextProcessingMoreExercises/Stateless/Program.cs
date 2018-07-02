using System;
using System.Collections.Generic;

namespace Stateless
{
    public class Program
    {
        public static void Main()
        {
            var state = Console.ReadLine();
            var memory = new Dictionary<string, string>();

            while (state != "collapse")
            {
                var fiction = Console.ReadLine();
                memory[state] = fiction;

                state = Console.ReadLine();
            }

            var statelessList = new List<string>();

            foreach (var memo in memory)
            {
                string statelessWord = ConvertWordToStatless(memo);
                statelessList.Add(statelessWord);
            }

            PrintStatlessStrings(statelessList);
        }

        public static string ConvertWordToStatless(KeyValuePair<string, string> memo)
        {
            string modState = memo.Key;
            string modFiction = memo.Value;

            //Remove substings of the fiction found in the state
            //Repeat while the modified fiction (a.k.a substinged fiction) exists 
            while (modFiction.Length > 1)
            {
                modState = modState.Replace(modFiction, String.Empty);
                modFiction = modFiction.Remove(0, 1);
                modFiction = modFiction.Remove(modFiction.Length - 1, 1);
            }
            if (modFiction.Length > 0)
            {
                modState = modState.Replace(modFiction, String.Empty);
            }

            return modState;
        }

        public static void PrintStatlessStrings(List<string> statelessList)
        {
            statelessList
                .ForEach(state =>
                {
                    if (state.Length > 0)
                    {
                        Console.WriteLine(state.Trim());
                    }
                    else
                    {
                        Console.WriteLine("(void)");
                    }
                });
        }
    }
}
