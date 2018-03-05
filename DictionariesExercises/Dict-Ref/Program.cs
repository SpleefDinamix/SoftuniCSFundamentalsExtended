using System;
using System.Collections.Generic;
using System.Linq;

namespace Dict_Ref
{
    public class Program
    {
        public static void Main()
        {
            var selfRefDict = new Dictionary<string,int>();
            var input = Console.ReadLine();
            

            while(input != "end")
            {
                var components = input.Split();
                string componentKey = components[0];
                string componentValue = components[components.Length-1];
                int parsedValue;

                bool isValueOrAnEntry = int.TryParse(componentValue, out parsedValue);

                if (isValueOrAnEntry)
                {
                    selfRefDict[componentKey] = parsedValue;
                }
                else
                {
                    if (selfRefDict.ContainsKey(componentValue))
                    {
                        selfRefDict[componentKey] = selfRefDict[componentValue];
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var kvp in selfRefDict)
            {
                Console.WriteLine($"{kvp.Key} === {kvp.Value}");
            }
        }
    }
}
