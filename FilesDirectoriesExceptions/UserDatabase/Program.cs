using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace UserDatabase
{
    public class Program
    {
        public static void Main()
        {
            var localDatabase = new Dictionary<string, string>();
            bool isLoggedIn = false;
            var inputLine = Console.ReadLine();

            if (File.Exists("../../database/database.txt"))
            {
                string[] globalDatabase = File.ReadAllLines("../../database/database.txt");
                ImportUsers(localDatabase, globalDatabase);
            }

            while (inputLine != "exit")
            {
                var parts = inputLine.Split();

                if (parts[0] == "register")
                {
                    Register(localDatabase, parts);
                }
                else if (parts[0] == "login")
                {
                    isLoggedIn = Login(localDatabase, isLoggedIn, parts);
                }
                else
                {
                    isLoggedIn = Logout(isLoggedIn);
                }

                inputLine = Console.ReadLine();
            }

            var finalDatabase = localDatabase.Select(x => x.Key + " " + x.Value).ToArray();
            File.WriteAllLines("../../database/database.txt", finalDatabase);
        }

        public static bool Logout(bool isLoggedIn)
        {
            if (isLoggedIn)
            {
                isLoggedIn = false;
            }
            else
            {
                Console.WriteLine("There is no currently logged in user.");
            }

            return isLoggedIn;
        }

        public static bool Login(Dictionary<string, string> localDatabase, bool isLoggedIn, string[] parts)
        {
            string name = parts[1];
            string password = parts[2];

            if (isLoggedIn)
            {
                Console.WriteLine("There is already a logged in user.");
            }
            else
            {
                if (localDatabase.ContainsKey(name))
                {
                    if (localDatabase[name] == password)
                    {
                        isLoggedIn = true;
                    }
                    else
                    {
                        Console.WriteLine("The password you entered is incorrect.");
                    }
                }
                else
                {
                    Console.WriteLine("There is no user with the given username.");
                }
            }

            return isLoggedIn;
        }

        public static void Register(Dictionary<string, string> localDatabase, string[] parts)
        {
            string name = parts[1];
            string password = parts[2];
            string confirmPassword = parts[3];

            try
            {
                if (password == confirmPassword)
                {
                    localDatabase.Add(parts[1], parts[2]);
                }
                else
                {
                    Console.WriteLine("The two passwords must match.");
                }

            }
            catch (ArgumentException)
            {
                Console.WriteLine("The given username already exists.");
            }
        }

        public static void ImportUsers(Dictionary<string, string> database, string[] loadedUsers)
        {
            foreach (var user in loadedUsers)
            {
                string[] parts = user.Split(' ');
                string username = parts[0];
                string password = parts[1];

                try
                {
                    database.Add(username, password);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("*** Failed to load data ***");
                    Console.WriteLine("There is already a logged in user.");
                    Console.WriteLine();
                }
            }
        }
    }
}
