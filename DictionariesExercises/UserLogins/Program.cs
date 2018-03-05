using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLogins
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dataBase = new Dictionary<string,string>();
            var register = Console.ReadLine();

            while (register != "login")
            {
                string username ,password;
                separateInputPair(register,out username,out password);
                dataBase[username] = password;

                register = Console.ReadLine();
            }

            var login = Console.ReadLine();
            int fails = 0;

            while (login != "end")
            {
                string username, password;
                separateInputPair(login, out username, out password);

                if (dataBase.ContainsKey(username) && dataBase[username] == password)
                {
                    Console.WriteLine($"{username}: logged in successfully");
                }
                else
                {
                    Console.WriteLine($"{username}: login failed");
                    fails++;
                }

                login = Console.ReadLine();
            }

            Console.WriteLine($"unsuccessful login attempts: {fails}");

        }

        public static void separateInputPair(string input, out string username, out string password)
        {
            var package = input.Split();
            username = package.First();
            password = package.Last();
        }
    }
}
