using System;

namespace Nilapdromes
{
    public class Program
    {
        public static void Main()
        {
            var word = Console.ReadLine();

            while (word != "end")
            {
                string nalapadrome = CreateNalapadrome(word);
                if (nalapadrome != "invalid")
                {
                    Console.WriteLine(nalapadrome);
                }
                
                word = Console.ReadLine();
            }
        }

        public static string CreateNalapadrome(string word)
        {
            string leftBorder = String.Empty;
            string rightBorder = String.Empty;

            string border = String.Empty;
            for (int i = 0; i < word.Length / 2; i++)
            {
                leftBorder = word.Substring(0 , (i + 1));
                rightBorder = word.Substring(word.Length - (i + 1));
                if (leftBorder == rightBorder)
                {
                    border = leftBorder;
                }
            }

            if (border != String.Empty)
            {
                string core = word.Replace(border, String.Empty);
                return core != String.Empty ? core + border + core : "invalid";
            }
            else
                return "invalid";
        }
    }
}
