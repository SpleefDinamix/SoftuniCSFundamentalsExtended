using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HTMLContents
{
    public class Program
    {
        public static void Main()
        {
            var htmlTemplete = new List<string>()
            {
                "<!DOCTYPE html>", "<html>", "<head>", "</head>","<body>","</body>","</html>"
            };
            var headContent = new List<string>();
            var bodyContent = new List<string>();

            var inputLine = Console.ReadLine();

            while (inputLine != "exit")
            {
                var parts = inputLine.Split();
                string tag = parts[0];
                string content = parts[1];

                if (tag == "title")
                {
                    if (!headContent.Contains("<title>"))
                    {
                        headContent.Add("<title>");
                        headContent.Add(content);
                        headContent.Add("</title>");
                    }
                    else
                    {
                        headContent.RemoveAt(headContent.IndexOf("<title>") + 1);
                        headContent.Insert(headContent.IndexOf("</title>"), content);
                    }
                }
                else
                {
                    bodyContent.Add('<' + tag + '>');
                    bodyContent.Add(content);
                    bodyContent.Add("</" + tag + '>');
                }

                inputLine = Console.ReadLine();
            }

            var modifiedHeadContent = new List<string>();
            for (int i = 0; i < headContent.Count; i += 3)
            {
                modifiedHeadContent.Add(String.Join("", headContent.Skip(i).Take(3)));
            }
            modifiedHeadContent = modifiedHeadContent.Select(x => x = "\t" + x).ToList();

            var modifiedBodyContent = new List<string>();
            for (int i = 0; i < bodyContent.Count; i += 3)
            {
                modifiedBodyContent.Add(String.Join("", bodyContent.Skip(i).Take(3)));
            }
            modifiedBodyContent = modifiedBodyContent.Select(x => x = "\t" + x).ToList();

            htmlTemplete.InsertRange(3, modifiedHeadContent);
            htmlTemplete.InsertRange(6, modifiedBodyContent);

            htmlTemplete
                .ForEach(Console.WriteLine);

            File.WriteAllLines("../../output/htmlComponents.html", htmlTemplete);
        }
    }
}
