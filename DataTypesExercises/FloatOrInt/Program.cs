using System;

namespace FloatOrInt
{
    public class Program
    {
       public static void Main()
        {
            var userInput = (int)Math.Round(double.Parse(Console.ReadLine()));
            Console.WriteLine(userInput);

        }
    }
}
