using System;
using System.Linq;
using System.Collections.Generic;

namespace ShootListElements
{
    public class Program
    {
        public static void Main()
        {
            var intList = new List<int>();
            int lastItem = -1;
            string output = String.Empty;

            string userInput = Console.ReadLine();

            while (userInput != "stop")
            {

                if (userInput != "bang")
                {
                    int item = int.Parse(userInput);
                    intList.Insert(0,item);
                }

                else if(userInput == "bang" && intList.Count == 0)
                {
                    output = $"nobody left to shoot! last one was {lastItem}";
                    break;
                }

                else if(userInput == "bang")
                {
                    ShootElements(intList,ref lastItem);
                }
                userInput = Console.ReadLine();
            }

            string survivors = $"survivors: {String.Join(" ",intList)}";

            if (userInput == "stop" && intList.Count == 0)
            {
                output = $"you shot them all. last one was {lastItem}";
            }
            else if(output == String.Empty)
            {
                output = survivors;
            }
             
            Console.WriteLine(output);
            
        }

        private static void ShootElements(List<int> intList, ref int lastItem)
        {

            for (int i = 0; i < intList.Count; i++)
            {
                double average = (double)intList.Sum() / intList.Count();

                //Removing ints that are less then the average of the intList
                if(intList[i] <= average)
                {
                    lastItem = intList[i];
                    Console.WriteLine($"shot {intList[i]}");
                    intList.RemoveAt(i);
                    DecrementIntList(intList);
                    break;
                }
            }
        }

        private static void DecrementIntList(List<int> intList)
        {
            for (int i = 0; i < intList.Count; i++)
            {
                intList[i]--;
            }
        }
    }
}
