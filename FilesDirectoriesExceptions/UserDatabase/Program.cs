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
            var database = new Dictionary<string, string>();
            bool isLoggedIn = false;
            var inputLine = Console.ReadLine();

            if (File.Exists("../../database/database.txt"))
            {
                string[] loadedUsers = File.ReadAllLines("../../database/database.txt");
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

            while (inputLine != "exit")
            {
                var parts = inputLine.Split();

                if (parts[0] == "register")
                {
                    string name = parts[1];
                    string password = parts[2];
                    string confirmPassword = parts[3];

                    try
                    {
                        if (password == confirmPassword)
                        {
                            database.Add(parts[1], parts[2]);
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
                else if (parts[0] == "login") 
                {
                    string name = parts[1];
                    string password = parts[2];

                    if (isLoggedIn)
                    {
                        Console.WriteLine("There is already a logged in user.");
                    }
                    else
                    {
                        if (database.ContainsKey(name))
                        {
                            if (database[name] == password)
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
                }
                else
                {
                    if (isLoggedIn)
                    {
                        isLoggedIn = false;
                    }
                    else
                    {
                        Console.WriteLine("There is no currently logged in user.");
                    }
                }

                inputLine = Console.ReadLine();
            }

            var finalDatabase = database.Select(x => x.Key + " " + x.Value).ToArray();
            File.WriteAllLines("../../database/database.txt", finalDatabase);
        }
    }
}
