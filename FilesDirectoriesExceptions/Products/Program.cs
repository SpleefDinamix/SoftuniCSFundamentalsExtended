using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;

namespace Products
{
    public class Product
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            var database = new List<string>();
            LoadDatabase(ref database);

            var products = new List<Product>();
            CreateProductsFromData(database, products);

            var inputLine = Console.ReadLine();

            while (inputLine != "exit")
            {
                if (inputLine == "stock")
                {
                    var newDatabase = new List<string>();
                    CreateDatabaseFromProducts(newDatabase, products);
                    File.WriteAllLines("../../database/database.txt", newDatabase);
                }
                else if (inputLine == "analyze")
                {
                    LoadDatabase(ref database);
                    CreateProductsFromData(database, products);

                    var alalyzeProducts = products
                        .OrderBy(x => x.Type)
                        .ToList();

                    foreach (var item in alalyzeProducts)
                    {  
                        Console.WriteLine("{0}, Product: {1}", item.Type, item.Name);
                        Console.WriteLine("Price: ${0}, Amount Left: {1}", item.Price, item.Quantity);
                    }
                }
                else if (inputLine == "sales")
                {
                    //TODO
                }
                else
                {
                    AddOrUpdateProducts(products, inputLine);
                }
                
                inputLine = Console.ReadLine();
            }
        }

        public static void CreateDatabaseFromProducts(List<string> newDatabase, List<Product> products)
        {
            foreach (var product in products)
            {
                newDatabase.Add(product.Name + " " + product.Type + " " + product.Price + " " + product.Quantity);
            }
        }

        public static void AddOrUpdateProducts(List<Product> products, string inputLine)
        {
            var parts = inputLine.Split(' ');
            string name = parts[0];
            string type = parts[1];
            decimal price = decimal.Parse(parts[2], CultureInfo.InvariantCulture);
            int quantity = int.Parse(parts[3]);

            foreach (var product in products)
            {
                if (product.Name == name && product.Type == type)
                {
                    product.Price = price;
                    product.Quantity = quantity;
                }
            }

            products.Add(new Product()
            {
                Name = name,
                Type = type,
                Price = price,
                Quantity = quantity
            });
        }

        public static void CreateProductsFromData(List<string> database, List<Product> products)
        {
            foreach (var item in database)
            {
                var itemParts = item.Split(' ');
                
                string name = itemParts[0];
                string type = itemParts[1];
                decimal price = decimal.Parse(itemParts[2],CultureInfo.InvariantCulture);
                int quantity = int.Parse(itemParts[3]);

                products.Add(new Product()
                {
                    Name = name,
                    Type = type,
                    Price = price,
                    Quantity = quantity
                });
            }
        }

        public static void LoadDatabase(ref List<string> database)
        {
            if (File.Exists("../../database/database.txt"))
            {
                database = File.ReadAllLines("../../database/database.txt").ToList();
            }
        }
    }
}
