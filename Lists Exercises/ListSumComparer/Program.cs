using System;
using System.Linq;

namespace ListSumComparer
{
    public class Program
    {
        public static void Main()
        {
            var firstList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var secondList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            for(int f=0; f < firstList.Count; f++)
            {
                for(int s=0; s < secondList.Count; s++)
                {
                    if(firstList[f] == secondList[s])
                    {
                        secondList.RemoveAt(s);
                    }
                }
            }
            
            if(firstList.Sum() == secondList.Sum())
            {
                Console.WriteLine("Yes. Sum: " + firstList.Sum());
            }
            else
            {
                Console.WriteLine("No. Diff: " + Math.Abs(firstList.Sum() - secondList.Sum()));
            }
        }
    }
}
