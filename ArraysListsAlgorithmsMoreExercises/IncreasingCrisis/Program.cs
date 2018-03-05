using System;
using System.Collections.Generic;
using System.Linq;

namespace IncreasingCrisis
{
    public class Program
    {
        public static void Main()
        {
            int times = int.Parse(Console.ReadLine());
            var sequence = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToList();

            for (int i = 1; i < times; i++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToList();

                InsertElements(sequence, input);
                CuttTheList(sequence);
            }

            Console.WriteLine(String.Join(" ",sequence));
        }

        private static void CuttTheList(List<int> sequence)
        {
            for (int i = 0; i < sequence.Count - 1; i++)
            {
                if(sequence[i + 1] < sequence[i])
                {
                    sequence.RemoveRange(i+1,sequence.Count - (i+1));
                }
            }
        }

        public static void InsertElements(List<int> sequence, List<int> input)
        {
            for (int j = sequence.Count - 1; j > 0; j--)
            {
                if (sequence[j] <= input[0])
                {
                    sequence.InsertRange(j + 1, input);
                    break;
                }
            }
        }
    }
}
