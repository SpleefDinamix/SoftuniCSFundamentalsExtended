using System;
using System.Linq;


namespace UnunionLists
{
    public class Program
    {
        public static void Main()
        {
            var mainList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var diffList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

                for (int j = 0; j < diffList.Count; j++)
                {
                    if (mainList.Contains(diffList[j]))
                    {
                        mainList.Remove(diffList[j]);
                    }
                    else
                    {
                        mainList.Add(diffList[j]);
                    }
                }

            }
            mainList.Sort();
            Console.WriteLine(String.Join(" ", mainList));
        }
    }
}
