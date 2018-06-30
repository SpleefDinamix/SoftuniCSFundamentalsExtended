using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace CapitalizeWords
{
    public class Program
    {
        public static void Main()
        {
            var sentence = Console.ReadLine();

            while (sentence != "end")
            {
                CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;

                var words = sentence
                    .Split(new[] { ' ', ',', '.', '?', '!', '(', ')', '-', '+', '*', '/', '#', ':', ';', '=' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => textInfo.ToTitleCase(x))
                    .ToArray();

                Console.WriteLine(String.Join(", ",words));
                sentence = Console.ReadLine();
            }
        }
    }
}
