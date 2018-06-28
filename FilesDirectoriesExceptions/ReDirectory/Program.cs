using System;
using System.Linq;
using System.IO;

namespace ReDirectory
{
    public class Program
    {
        public static void Main()
        {
            string[] files = Directory.GetFiles("../../input");

            foreach (var file in files)
            {
                var fileParts = file.Split('\\').Last().Split('.');
                string fileName = String.Join(".", fileParts.Take(fileParts.Length - 1));
                string fileExtension = fileParts.Skip(fileParts.Length - 1).ToArray()[0];

                if (!Directory.Exists("../../output/" + fileExtension + "s"))
                {
                    Directory.CreateDirectory("../../output/" + fileExtension + "s");
                }

                File.Copy(file, "../../output/" + fileExtension + "s/" + fileName + '.' + fileExtension);
            }
        }
    }
}
