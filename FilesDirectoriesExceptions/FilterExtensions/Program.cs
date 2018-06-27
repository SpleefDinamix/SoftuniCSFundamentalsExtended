using System;
using System.IO;
using System.Linq;

namespace FilterExtensions
{
    public class Program
    {
        public static void Main()
        {
            string[] files = Directory.GetFiles("../../input");
            var fileExtension = Console.ReadLine();

            foreach (var file in files)
            {
                if (file.Split('.').Last() == fileExtension)
                {
                    string result = file.Split('\\').Last();
                    Console.WriteLine(result);
                }
            }
        }
    }
}
