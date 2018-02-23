using System;

namespace LargestElement
{
    public class Program
    {
        public static void Main()
        {
            int times = int.Parse(Console.ReadLine());
            int[] numbers = new int[times];

            for (int i = 0; i < times; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }


            int currentNumber = int.MinValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if(currentNumber < numbers[i])
                {
                    currentNumber = numbers[i];
                }
            }
            

            Console.WriteLine(Environment.NewLine +  currentNumber);

        }
    }
}
