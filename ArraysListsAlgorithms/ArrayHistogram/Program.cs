using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayHistogram
{
    public class Program
    {
        public static void Main()
        {
            var words = Console.ReadLine()
                .Split()
                .ToArray();

            var destinctWords = words.Distinct().ToList();
            var count = new List<int>();
            ListWordCounter(words, destinctWords, count);
            DescendBubbleSort(destinctWords,count);
            double partPercentage = 100.0 / words.Length;

            for (int i = 0; i < destinctWords.Count; i++)
            {
                var percentage = count[i] * partPercentage;
                var outputString = $"{destinctWords[i]} -> {count[i]} times ({percentage:F2}%)";
                Console.WriteLine(outputString);
            }
            
        }


        private static void DescendBubbleSort(List<string> destinctWords, List<int> count)
        {
            bool swapped = false;
            do
            {
                swapped = false;
                for (int i = 0; i < destinctWords.Count - 1; i++)
                {
                    if (count[i] < count[i+1])
                    {
                        swapped = true;

                        var tempWord = destinctWords[i];
                        destinctWords[i] = destinctWords[i + 1];
                        destinctWords[i + 1] = tempWord;

                        var tempCount = count[i];
                        count[i] = count[i + 1];
                        count[i + 1] = tempCount;
                    }
                }
            } while (swapped);
        }

        public static void ListWordCounter(string[] words, List<string> destinctWords, List<int> count)
        {
            for (int i = 0; i < destinctWords.Count; i++)
            {
                var selectedWord = destinctWords[i];
                int wordCount = 0;
                for (int j = 0; j < words.Length; j++)
                {
                    if (selectedWord == words[j])
                    {
                        wordCount++;
                    }
                }
                count.Add(wordCount);
            }
        }
    }
}
