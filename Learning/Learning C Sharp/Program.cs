using System;

namespace Learning_C_Sharp
{
    class Program
    {
         static void Main(string[] args)
        {
            Console.WriteLine("Type your name here:");
            string userName = Console.ReadLine();
            Console.WriteLine("And what is your age");
            short userAge = Convert.ToInt16(Console.ReadLine());
            /*End of input, time for result*/

            if (userAge <= 10)
            {
                Console.WriteLine("Hello {0}. {1}? You are too young!", userName, userAge);
            }
            else if (userAge > 10 && userAge <= 20)
            {
                Console.WriteLine("Hello {0}. {1} is the perfect age!", userName, userAge);
            }
            else if (userAge > 20)
            {
                Console.WriteLine("Hello {0}. Time to have kids!", userName);
            }
            
        }


    }
}
