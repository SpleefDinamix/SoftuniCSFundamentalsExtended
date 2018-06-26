using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveOdd
{
    public class Program
    {
        public static void Main()
        {
            List<string> words = Console.ReadLine().Split(' ').ToList();
            List<string> result = new List<string>();
            
            for(int x = 0; x < words.Count; x++)
            {
                if(x % 2 != 0)
                {
                    result.Add(words[x]);
                }
            }
            Console.WriteLine(String.Join("",result));
        }
    }
}
