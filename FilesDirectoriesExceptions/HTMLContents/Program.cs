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
                    CreateOrUpdateTitle(headContent, content);
                }
                else
                {
                    AddBodyContent(bodyContent, tag, content);
                }

                inputLine = Console.ReadLine();
            }

            //Format And Concat tags and content in Head
            var modifiedHeadContent = new List<string>();
            FormatTags(headContent, modifiedHeadContent);
            modifiedHeadContent = modifiedHeadContent.Select(x => x = "\t" + x).ToList();

            //Format And Concat tags and content in Body
            var modifiedBodyContent = new List<string>();
            FormatTags(bodyContent, modifiedBodyContent);
            modifiedBodyContent = modifiedBodyContent.Select(x => x = "\t" + x).ToList();

            htmlTemplete.InsertRange(3, modifiedHeadContent);
            htmlTemplete.InsertRange(6, modifiedBodyContent);

            htmlTemplete
                .ForEach(Console.WriteLine);

            File.WriteAllLines("../../output/htmlComponents.html", htmlTemplete);
        }

        public static void FormatTags(List<string> content, List<string> modifiedContent)
        {
            for (int i = 0; i < content.Count; i += 3)
            {
                modifiedContent.Add(String.Join("", content.Skip(i).Take(3)));
            }
        }

        public static void AddBodyContent(List<string> bodyContent, string tag, string content)
        {
            bodyContent.Add('<' + tag + '>');
            bodyContent.Add(content);
            bodyContent.Add("</" + tag + '>');
        }

        public static void CreateOrUpdateTitle(List<string> headContent, string content)
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
    }
}
