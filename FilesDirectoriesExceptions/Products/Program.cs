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
                    if (database.Count != 0)
                    {
                        var stockedProducts = new List<Product>();
                        CreateProductsFromData(database, stockedProducts);

                        var alalyzedProducts = stockedProducts
                            .OrderBy(x => x.Type)
                            .ToList();

                        foreach (var item in alalyzedProducts)
                        {
                            Console.WriteLine("{0}, Product: {1}", item.Type, item.Name);
                            Console.WriteLine("Price: ${0}, Amount Left: {1}", item.Price, item.Quantity);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No products stocked");
                    }
                }
                else if (inputLine == "sales")
                {
                    var income = new Dictionary<string, decimal>()
                    {
                        {"Food",0M}, {"Electronics",0M}, {"Domestics",0M}
                    };

                    SumIncomeAndPrint(products, income , "Food", "Electronics", "Domestics");
                }
                else
                {
                    AddOrUpdateProducts(products, inputLine);
                }
                
                inputLine = Console.ReadLine();
            }
        }

        public static void SumIncomeAndPrint(List<Product> products, Dictionary<string, decimal> income, params string[] types)
        {
            foreach (var type in types)
            {
                products
                .Where(x => x.Type == type)
                .ToList()
                .ForEach(x => income[type] += x.Price * x.Quantity);
            }

            income
                .OrderByDescending(x => x.Value)
                .Where(x => x.Value > 0M)
                .ToList()
                .ForEach(x =>
                {
                    Console.WriteLine("{0}: ${1:F2}", x.Key, x.Value);
                });
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

            bool isAProductUpdate = false;
            foreach (var product in products)
            {
                if (product.Name == name && product.Type == type)
                {
                    product.Price = price;
                    product.Quantity = quantity;
                    isAProductUpdate = true;
                }
            }
            if (!isAProductUpdate)
            {
                products.Add(new Product()
                {
                    Name = name,
                    Type = type,
                    Price = price,
                    Quantity = quantity
                });
            }
        }

        public static void CreateProductsFromData(List<string> database, List<Product> products)
        {
            foreach (var item in database)
            {
                var itemParts = item.Split(' ');
                
                string name = itemParts[0];
                string type = itemParts[1];
                decimal price = decimal.Parse(itemParts[2],CultureInfo.CurrentCulture);
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