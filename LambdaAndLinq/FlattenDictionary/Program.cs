using System;
using System.Collections.Generic;
using System.Linq;

namespace FlattenDictionary
{
    public class Program
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var mainDict = new Dictionary<string, Dictionary<string, string>>();

            while (inputLine != "end")
            {
                var parts = inputLine
                        .Split()
                        .ToArray();

                if (parts[0] != "flatten")
                {

                    if (!mainDict.ContainsKey(parts[0]))
                    {
                        mainDict.Add(parts[0], new Dictionary<string, string>());
                    }

                    mainDict[parts[0]][parts[1]] = parts[2];
                }
                else
                {
                    mainDict[parts[1]] = mainDict[parts[1]]
                        .ToDictionary(x => x.Key + x.Value, x => "flattened");
                }

                inputLine = Console.ReadLine();
            }

            mainDict = mainDict
                .OrderByDescending(x => x.Key.Length)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in mainDict)
            {
                Console.WriteLine(kvp.Key);
                int indexer = 1;

                var orderedInnerDict = kvp.Value
                        .Where(x => x.Value != "flattened")
                        .OrderBy(x => x.Key.Length)
                        .ToDictionary(x => x.Key, x => x.Value);

                var flattenedValues = kvp.Value
                        .Where(x => x.Value == "flattened")
                        .ToDictionary(x => x.Key, x => x.Value);

                foreach (var orderedEntry in orderedInnerDict)
                {
                    Console.WriteLine(indexer + ". " + orderedEntry.Key + " - " + orderedEntry.Value);
                    indexer++;
                }
                foreach (var flattenedEntry in flattenedValues)
                {
                    Console.WriteLine(indexer + ". " + flattenedEntry.Key);
                    indexer++;
                }
            }
        }
    }
}
