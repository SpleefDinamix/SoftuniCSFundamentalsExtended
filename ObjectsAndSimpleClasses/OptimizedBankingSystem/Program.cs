using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace OptimizedBankingSystem
{
    public class Program
    {
        public static void Main()
        {
            string inputLine = Console.ReadLine();
            var accounts = new List<BankAccount>();

            while (inputLine != "end")
            {
                var parts = inputLine
                    .Split(new[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);

                accounts.Add(new BankAccount
                {
                    Bank = parts[0],
                    Name = parts[1],
                    Balance = decimal.Parse(parts[2], CultureInfo.InvariantCulture)
                });

                inputLine = Console.ReadLine();
            }

            accounts = accounts
                .OrderByDescending(x => x.Balance)
                .ThenBy(x => x.Bank.Length)
                .ToList();

            foreach (var bankAccount in accounts)
            {
                Console.WriteLine("{0} -> {1} ({2})",
                    bankAccount.Name,
                    bankAccount.Balance,
                    bankAccount.Bank);
            }
        }
    }
}
