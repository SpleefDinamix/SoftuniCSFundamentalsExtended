using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterBase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var empAge = new Dictionary<string,int>();
            var empSalary = new Dictionary<string,double>();
            var empPosition = new Dictionary<string,string>();

            string input = Console.ReadLine();

            while(input != "filter base")
            {
                var parts = input.Split();
                string name = parts.First();
                //Atribute is will go to the empPosition dict by defaut
                string atribute = parts.Last();
                int age;
                double salary;

                bool isAge = int.TryParse(atribute,out age);
                bool isSalary = double.TryParse(atribute,out salary);

                if (isAge)
                {
                    empAge[name] = age;
                }
                else if (isSalary)
                {
                    empSalary[name] = salary;
                }
                else
                {
                    empPosition[name] = atribute;
                }

                input = Console.ReadLine();
            }

            string filter = Console.ReadLine();

            switch(filter)
            {
                case "Age":
                    PrintTemplate("Age",empAge);
                    break;

                case "Salary":
                    PrintTemplate("Salary", empSalary);
                    break;

                default:
                    PrintTemplate("Position", empPosition);
                    break;
            }
        }

        public static void PrintTemplate(string atribute, Dictionary<string, int> empPart)
        {
            foreach (var kvp in empPart)
            {
                Console.WriteLine($"Name: {kvp.Key}");
                Console.WriteLine($"{atribute}: {kvp.Value}");
                Console.WriteLine(new String('=',20));
            } 
        }

        public static void PrintTemplate(string atribute, Dictionary<string, double> empPart)
        {
            foreach (var kvp in empPart)
            {
                Console.WriteLine($"Name: {kvp.Key}");
                Console.WriteLine($"{atribute}: {kvp.Value:F2}");
                Console.WriteLine(new String('=', 20));
            }
        }

        public static void PrintTemplate(string atribute, Dictionary<string, string> empPart)
        {
            foreach (var kvp in empPart)
            {
                Console.WriteLine($"Name: {kvp.Key}");
                Console.WriteLine($"{atribute}: {kvp.Value}");
                Console.WriteLine(new String('=', 20));
            }
        }

    }
}
