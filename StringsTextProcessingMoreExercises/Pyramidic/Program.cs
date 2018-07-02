using System;
using System.Collections.Generic;
using System.Linq;

namespace Pyramidic
{
    public class Program
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            var counter = new Dictionary<char, int>[rows];

            for (int i = 0; i < counter.Length; i++)
            {
                var chars = Console.ReadLine();
                char[] uniqueChars = chars.Distinct().ToArray();
                counter[i] = new Dictionary<char, int>();

                foreach (var uChar in uniqueChars)
                {
                    if (!counter[i].Keys.Contains(uChar))
                    {
                        counter[i].Add(uChar, 0);
                    }

                    int lastIndex = chars.IndexOf(uChar);
                    counter[i][uChar] += 1;

                    while (true)
                    {
                        int nextIndex = chars.IndexOf(uChar, lastIndex + 1);
                        if (nextIndex < 0)
                        {
                            break;
                        }
                        counter[i][uChar] += 1;
                        lastIndex = nextIndex;
                    }
                }
            }

            var tracer = new Dictionary<char, int>();
            var comparer = new Dictionary<char, int>();

            for (int i = 0; i < counter.Length - 1; i++)
            {
                foreach (var chr in counter[i].Keys)
                {
                    if (!tracer.Keys.Contains(chr))
                    {
                        tracer[chr] = 1;
                    }

                    if (!counter[i + 1].Keys.Contains(chr))
                    {
                        continue;
                    }
                    else if (counter[i + 1][chr] >= tracer[chr] + 2)
                    {
                        if (!comparer.Keys.Contains(chr))
                        {
                            comparer[chr] = 1;
                        }

                        comparer[chr] += tracer[chr] + 2;
                        tracer[chr] += 2;
                    }
                    else
                    {
                        continue;
                    }
                }
            }


            foreach (var chr in comparer)
            {
                Console.WriteLine(chr.Key + ": " + chr.Value);
            }

            var final = comparer
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value)
                .First();

            int drawIndex = 1;
            while (drawIndex <= tracer[final.Key])
            {
                Console.WriteLine(new String(final.Key, drawIndex));
                drawIndex += 2;
            }
        }
    }
}
