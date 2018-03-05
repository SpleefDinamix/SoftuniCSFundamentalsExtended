using System;
using System.Collections.Generic;

namespace ExamShopping
{
    public class Program
    {
        public static void Main()
        {
            var shopInventory = new Dictionary<string,int>();
            var itemToAdd = Console.ReadLine();

            while (itemToAdd != "shopping time")
            {
                string product;
                int quantity;
                UnpackageItems(itemToAdd, out product, out quantity);

                if (!shopInventory.ContainsKey(product))
                {
                    shopInventory[product] = quantity;
                }
                else
                {
                    shopInventory[product] += quantity; 
                }

                itemToAdd = Console.ReadLine();
            }

            var itemToSell = Console.ReadLine();

            while (itemToSell != "exam time")
            {
                string product;
                int quantity;
                UnpackageItems(itemToSell,out product,out quantity);

                if (shopInventory.ContainsKey(product))
                {
                    if (shopInventory[product] > 0)
                    {
                        shopInventory[product] -= quantity;
                        if (shopInventory[product] < 0)
                        {
                            shopInventory[product] = 0;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{product} out of stock");
                    }
                    
                }
                else
                {
                    Console.WriteLine($"{product} doesn't exist");
                }

                itemToSell = Console.ReadLine();
            }

            foreach (var kvp in shopInventory)
            {
                if (kvp.Value != 0)
                {
                    Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                }
            }
        }

        public static void UnpackageItems(string itemToUnbox, out string product, out int quantity)
        {
            var package = itemToUnbox.Split();
            product = package[1];
            quantity = int.Parse(package[2]);
        }
    }
}
