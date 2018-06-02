using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace RegisteredUsers
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var registry = new Dictionary<string, DateTime>();

            while (input != "end")
            {
                var parts = input
                    .Split(new[] { " -> " }, StringSplitOptions.None);
                registry[parts.First()] = DateTime.ParseExact(parts.Last(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                input = Console.ReadLine();
            }

            var result = registry
                .Reverse()
                .OrderBy(x => x.Value)
                .Take(5)
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var user in result.Keys)
            {
                Console.WriteLine(user);
            }
        }
    }
}
