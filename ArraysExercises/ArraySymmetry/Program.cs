using System;
using System.Linq;

namespace ArraySymmetry
{
    class Program
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split(' ').ToArray();
            var result = String.Empty;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == words[words.Length -1 - i])
                {
                    result = "Yes";
                }
                else
                {
                    result = "No";
                    break;
                }
            }

            Console.WriteLine(result);

        }
    }
}
