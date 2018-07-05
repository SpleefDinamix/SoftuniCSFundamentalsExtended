using System;
using System.Text.RegularExpressions;

namespace FishStatistics
{
    public class Program
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var validator = new Regex(@"(>*)<(\(+)(['\-x])>");

            MatchCollection matches = validator.Matches(inputLine);
            if (matches.Count < 1)
            {
                Console.WriteLine("No fish found.");
                return;
            }

            int index = 1;
            foreach (Match fish in matches)
            {
                Console.WriteLine($"Fish {index}: " + fish.Value);
                var fishParts = fish.Groups;

                int fishTail = fishParts[1].Value.Length;
                int fishBody = fishParts[2].Value.Length;
                char statusExpression = char.Parse(fishParts[3].Value);

                string tailLenghtInCM = fishTail > 0 ? $" ({fishTail * 2} cm)" : String.Empty;
                Console.WriteLine($"  Tail type: {FindTypeOfTail(fishTail)}{tailLenghtInCM}");
                Console.WriteLine($"  Body type: {FindTypeOfBody(fishBody)} ({fishBody * 2} cm)");
                Console.WriteLine($"  Status: {FindStatus(statusExpression)}");

                index++;
            }
        }

        public static string FindStatus(char statusExpression)
        {
            string status;
            switch (statusExpression)
            {
                case '\'':
                    status = "Awake";
                    break;

                case '-':
                    status = "Asleep";
                    break;

                default:
                    status = "Dead";
                    break;
            }
            return status;
        }

        public static string FindTypeOfBody(int fishBody)
        {
            string bodyLenght;
            if (fishBody > 10)
                bodyLenght = "Long";

            else if (fishBody > 5)
                bodyLenght = "Medium";
            else
                bodyLenght = "Short";

            return bodyLenght;
        }

        public static string FindTypeOfTail(int fishTail)
        {
            string tailLenght;
            if (fishTail > 5)
                tailLenght = "Long";
            else if (fishTail > 1)
                tailLenght = "Medium";
            else if (fishTail == 1)
                tailLenght = "Short";
            else
                tailLenght = "None";

            return tailLenght;
        }
    }
}
