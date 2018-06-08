using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderedBankingSystem
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var banks = new Dictionary<string, Dictionary<string, decimal>>();

            while (input != "end")
            {
                string[] parts = input
                    .Split(new [] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

                string bankName = parts[0];
                string account = parts[1];

                var numberFormatInfo = new System.Globalization.NumberFormatInfo { NumberDecimalSeparator = "." };
                decimal balance = decimal.Parse(parts[2],numberFormatInfo);

                if (!banks.ContainsKey(bankName))
                {
                    banks.Add(bankName, new Dictionary<string, decimal>());
                }
                if (!banks[bankName].ContainsKey(account))
                {
                    banks[bankName].Add(account, 0);
                }
                banks[bankName][account] += balance;

                input = Console.ReadLine();
            }

            banks
                .OrderByDescending(bank => bank.Value.Sum(account => account.Value))
                .ThenByDescending(bank => bank.Value.Max(account => account.Value))
                .ToList()
                .ForEach(bank => bank.Value
                    .OrderByDescending(account => account.Value)
                    .ToList()
                    .ForEach(account => Console.WriteLine("{0} -> {1} ({2})",account.Key,account.Value,bank.Key)));
                
        }
    }
}
