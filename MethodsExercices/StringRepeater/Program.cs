using System;

namespace StringRepeater
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringToRepeat = Console.ReadLine();
            int times = int.Parse(Console.ReadLine());
            Console.WriteLine(RepeatString(stringToRepeat, times));
        }

        static string RepeatString(string str, int times)
        {
            string temp = string.Empty;
            for(int i = 0; i < times; i++)
            {
                temp += str;
            }
            return temp;
        }
    }
}
