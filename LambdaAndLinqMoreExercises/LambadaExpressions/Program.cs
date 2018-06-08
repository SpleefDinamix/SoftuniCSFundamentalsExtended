using System;
using System.Collections.Generic;
using System.Linq;

namespace LambadaExpressions
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var lambadaExpressions = new Dictionary<string, Dictionary<string, string>>();

            while (input != "lambada")
            {
                var parts = input
                    .Split(new char[] { ' ', '.', '=', '>' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length > 1)
                {
                    var selector = parts[0];
                    var selectorObject = parts[1];
                    var property = parts[2];

                    if (!lambadaExpressions.ContainsKey(selector))
                    {
                        lambadaExpressions.Add(selector, new Dictionary<string, string>());
                    }
                    lambadaExpressions[selector][selectorObject] = property;
                }
                else if (parts[0] == "dance")
                {
                    lambadaExpressions = lambadaExpressions
                        .ToDictionary(
                        selector => selector.Key,
                        selector => selector.Value
                            .ToDictionary(
                            selectorObject => selectorObject.Key,
                            selectorObject => selectorObject.Key + '.' + selectorObject.Value
                            ));
                }

                input = Console.ReadLine();
            }

            foreach (var expression in lambadaExpressions)
            {
                foreach (var selectorObject in expression.Value)
                {
                    Console.WriteLine(expression.Key + " => " + selectorObject.Key + '.' + selectorObject.Value);
                }
            }

        }
    }
}
