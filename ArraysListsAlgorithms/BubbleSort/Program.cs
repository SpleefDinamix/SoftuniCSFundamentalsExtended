using System;
using System.IO;
using System.Linq;

namespace BubbleSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ushort[] inputBuffer = new ushort[ushort.MaxValue];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));

            var array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            bool swapped = true;

            while (swapped)
            {
                swapped = false;
                BubbleSort(array, ref swapped);
            }
            ReverseArray(array);

            Console.WriteLine();
            Console.WriteLine(String.Join(" ", array));
        }

        //Reversing Algorith
        static void ReverseArray(int[] array)
        {
            for (int i = 0; i < array.Length/2; i++)
            {
                int temp = array[i];
                array[i] = array[array.Length-i-1];
                array[array.Length - i - 1] = temp;
            }
        }

        //Sorting Algorith Bubble Sort
        static void BubbleSort(int[] array, ref bool swapped)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    int temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                    swapped = true;
                }
            }
        }
    }
}
