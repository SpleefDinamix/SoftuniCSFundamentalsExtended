using System;
using System.Collections.Generic;
using System.Linq;

namespace Pyramidic
{
    public class Program
    {
        public static void Main()
        {
            //Number of rows
            int rows = int.Parse(Console.ReadLine());

            //The number of times a char is in a single row
            var counter = new Dictionary<char, int>[rows];

            for (int i = 0; i < counter.Length; i++)
            {
                //Reading a row of chars and extracting the unique ones
                var chars = Console.ReadLine();
                SumUniqueCharsOnOneRow(counter, i, chars);
            }

            //The treser records the last valid base on a char pyrimid
            var tracer = new Dictionary<char, int>();
            TraceTheBaseOfCharPyramids(counter, tracer);
            PrintLargestPyramid(tracer);
        }

        public static void PrintLargestPyramid(Dictionary<char, int> tracer)
        {
            var final = tracer
                            .OrderByDescending(x => x.Value)
                            .ToDictionary(x => x.Key, x => x.Value)
                            .First();

            int drawIndex = 1;
            while (drawIndex <= final.Value)
            {
                Console.WriteLine(new String(final.Key, drawIndex));
                drawIndex += 2;
            }
        }

        public static void TraceTheBaseOfCharPyramids(Dictionary<char, int>[] counter, Dictionary<char, int> tracer)
        {
            for (int i = 0; i < counter.Length - 1; i++)
            {
                foreach (var chr in counter[i].Keys)
                {
                    // If a char is not registered then it a new tracer with value of 1
                    // Trasers start from 1 as the top of the pyrimid is one in width
                    if (!tracer.Keys.Contains(chr))
                    {
                        tracer[chr] = 1;
                    }

                    bool nextWithSameChar = counter[i + 1].Keys.Contains(chr);
                    bool nextRowFollowsNextTracer = counter[i + 1][chr] >= tracer[chr] + 2;

                    if (nextWithSameChar && nextRowFollowsNextTracer)
                    {
                        //Update tracer, a.k.a increment it by 2
                        tracer[chr] += 2;
                    }
                }
            }
        }

        public static void SumUniqueCharsOnOneRow(Dictionary<char, int>[] counter, int rowIndex, string chars)
        {
            //Extract Unique Chars
            char[] uniqueChars = chars.Distinct().ToArray();
            counter[rowIndex] = new Dictionary<char, int>();

            foreach (var uChar in uniqueChars)
            {
                //Check if char is registered and asign a value
                if (!counter[rowIndex].Keys.Contains(uChar))
                {
                    counter[rowIndex].Add(uChar, 0);
                }

                //Find all char matches and sum them
                int lastIndex = chars.IndexOf(uChar);
                counter[rowIndex][uChar] += 1;

                while (true)
                {
                    int nextIndex = chars.IndexOf(uChar, lastIndex + 1);
                    //If no new match the IndexOf method returns -1 
                    if (nextIndex < 0)
                    {
                        break;
                    }
                    counter[rowIndex][uChar] += 1;
                    lastIndex = nextIndex;
                }
            }
        }
    }
}
