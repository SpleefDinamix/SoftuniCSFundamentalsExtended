using System;
using System.Linq;

namespace Placeholders
{
    public class Program
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();

            while (inputLine != "end")
            {
                var parts = inputLine
                    .Split(new[] { '-' , '>' },StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                string placeholder = parts[0];
                string[] words = parts[1]
                    .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < words.Length; i++)
                {
                    placeholder = placeholder
                        .Replace("{" + i + "}", words[i]);
                }
                
                Console.WriteLine(placeholder);
                inputLine = Console.ReadLine();
            }
        }
    }
}
