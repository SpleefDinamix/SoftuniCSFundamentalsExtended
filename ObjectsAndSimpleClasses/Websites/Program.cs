using System;
using System.Collections.Generic;
using System.Linq;

namespace Websites
{
    public class Program
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var websites = new List<Website>();

            while (inputLine != "end")
            {
                var parts = inputLine
                    .Split(new char[] { '|', ' '}, StringSplitOptions.RemoveEmptyEntries);

                var queries = new List<string>();
                if (parts.Length > 2)
                {
                    queries = parts[2]
                        .Split(new[] { ',', ' ' },StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
                }

                websites.Add(new Website() {
                    Host = parts[0],
                    Domain = parts[1],
                    Queries = queries.ToArray()
                });

                inputLine = Console.ReadLine();
            }

            foreach (var website in websites)
            {
                if (website.Queries.Length > 0)
                {
                    Console.Write("https://www.{0}.{1}/query?=", website.Host, website.Domain);
                    for (int i = 0; i < website.Queries.Length - 1; i++)
                    {
                        Console.Write("[{0}]&", website.Queries[i]);
                    }
                    Console.WriteLine("[{0}]", website.Queries[website.Queries.Length - 1]);
                }
                else
                {
                    Console.WriteLine("https://www.{0}.{1}", website.Host, website.Domain);
                }
            }
        }
    }
}
