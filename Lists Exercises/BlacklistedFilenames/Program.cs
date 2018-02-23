using System;
using System.Collections.Generic;
using System.Linq;

namespace BlacklistedFilenames
{
    public class Program
    {
        public static void Main()
        {
            List<string> blacklist = Console.ReadLine().Split(' ').ToList();
            List<string> filenames = new List<string>();
            string input = Console.ReadLine();

            while (input != "end")
            {
                 bool isBlacklisted = false;

                foreach (var bw in blacklist)
                {
                    if (input.Contains(bw))
                    {
                        isBlacklisted = true;
                        break;
                    }
                }

                if (!isBlacklisted)
                {
                    filenames.Add(input);
                }
                input = Console.ReadLine();
            }     
            
            filenames.Sort();
            Console.WriteLine(String.Join(Environment.NewLine,filenames));

        }
    }
}
