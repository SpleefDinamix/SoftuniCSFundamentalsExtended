using System;

namespace Phonebook
{
    public class Program
    {
        public static void Main()
        {
            string[] parts = Console.ReadLine().Split(' ');

            if (parts.Length >= 3)
            {
                for (int i = parts.Length - 1; i > 0; i--)
                {
                    if (parts[i] == parts[i - 1] && parts[i - 1] == parts[i - 2])
                    {
                        Console.WriteLine(parts[i] + " " + parts[i - 1] + " " + parts[i-2]);
                        break;
                    }
                }
            }
            
        }
    }
}
