using System;

namespace Calculator
{
    public class Program
    {
       public static void Main()
       {
           int operant = int.Parse(Console.ReadLine());
           var myOperator = Console.ReadLine();
           int secOperant = int.Parse(Console.ReadLine());
           int result = 0;

            switch (myOperator)
           {
                case "+":
                    result = operant + secOperant;
                    Console.WriteLine(operant + " " + myOperator + " " + secOperant + " = " + result);
                break;

               case "-":
                    result = operant - secOperant;
                   Console.WriteLine(operant + " " + myOperator + " " + secOperant + " = " + result);
               break;

               case "*":
                   result = operant * secOperant;
                   Console.WriteLine(operant + " " + myOperator + " " + secOperant + " = " + result);
                   break;

               case "/":
                   result = operant / secOperant;
                   Console.WriteLine(operant + " " + myOperator + " " + secOperant + " = " + result);
                   break;
            }

       }
    }
}
