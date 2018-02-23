using System;

namespace Phonebook
{
    public class Program
    {
        public static void Main()
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ');
            string[] names = Console.ReadLine().Split(' ');
            string targetedPerson = Console.ReadLine();

            while (targetedPerson != "done")
            {
                for (int i = 0; i < names.Length; i++)
                {
                    if (names[i] == targetedPerson)
                    {
                        Console.WriteLine($"{names[i]} -> {phoneNumbers[i]}");
                    }
                }

                targetedPerson = Console.ReadLine();
            }
        }
    }
}
