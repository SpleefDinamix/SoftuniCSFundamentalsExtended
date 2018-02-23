using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_C_Sharp___Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat;

            do
            {
                Console.WriteLine("<---------------Celsius/Farenheit Converter--------------->");
                Console.WriteLine();
                Console.WriteLine("Select conversion:");
                Console.WriteLine("1) Farenheit to Celsius");
                Console.WriteLine("2) Celsius to Farenheit");
                string usersChoice = Console.ReadLine();

                if (usersChoice == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Enter a value in Farenheit:");
                    double tempFarenheit = 0;
                    bool incorrect;

                    do
                    {
                        try
                        {
                            tempFarenheit = Convert.ToDouble(Console.ReadLine());
                            incorrect = false;
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("ENTER A VALID NUMBER!");
                            incorrect = true ;
                        }
                    } while (incorrect);

                    
                    
                    double result = (tempFarenheit - 32)/1.8;
                    Console.WriteLine("The Conversion Farenheit/Celsius is: {0}°C", Math.Round(result,2));
                    Console.WriteLine();
                    Console.WriteLine("Do you want to continue?(y/N)");

                    string toHaveRepeat = Console.ReadLine();
                    if (toHaveRepeat.ToLower() == "y")
                    {
                        repeat = true;
                        Console.Clear();
                    }
                    else
                    {
                        repeat = false;
                    }
                }

                else if (usersChoice == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Enter a value in Celsius:");
                    double tempCelsius = 0;
                    bool incorrect;

                    do
                    {
                        try
                        {
                            tempCelsius = Convert.ToDouble(Console.ReadLine());
                            incorrect = false;
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("ENTER A VALID NUMBER!");
                            incorrect = true;
                        }
                    } while (incorrect);

                    double result = tempCelsius * 1.8 + 32;
                    Console.WriteLine("The Conversion Celsius/Farenheit is: {0}°F", Math.Round(result,2));
                    Console.WriteLine();
                    Console.WriteLine("Do you want to continue?(Y/n)");

                    string toHaveRepeat = Console.ReadLine();
                    if (toHaveRepeat.ToLower() == "y")
                    {
                        repeat = true;
                        Console.Clear();
                    }
                    else
                    {
                        repeat = false;
                    }
                }

                else if (usersChoice.ToLower() == "exit")
                {
                    break;
                }

                else
                {
                    Console.Clear();
                    repeat = true;
                }

                
            } while (repeat);



        }
    }
}
