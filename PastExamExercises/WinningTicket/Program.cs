using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WinningTicket
{
    public class Program
    {
        public static void Main()
        {
            var tickets = Console.ReadLine()
                .Split(',')
                .Select(x => x.Trim())
                .ToArray();

            var matcher = new Regex(@"([$@#^])\1{5,}");

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                string modTicket = ticket.Insert(ticket.Length / 2, " ");
                var matches = matcher.Matches(modTicket);

                if (matches.Count == 2)
                {
                    var leftMatch = matches[0].Value;
                    var rightMatch = matches[1].Value;

                    //If they have the same win chars 
                    if (leftMatch[0] == rightMatch[0])
                    {
                        char luckyChar = leftMatch[0];
                        int count = Math.Min(leftMatch.Length, rightMatch.Length);

                        string ticketMatchText = $"ticket \"{ticket}\" - {count}{luckyChar}";

                        if (count == 10)
                            ticketMatchText += " Jackpot!";

                        Console.WriteLine(ticketMatchText);
                    }
                    else
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                    continue;
                }
            }
        }
    }
}
