using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            var dogDict = new Dictionary<string, Dog>();
            var catDict = new Dictionary<string, Cat>();
            var snakeDict = new Dictionary<string, Snake>();

            var inputLine = Console.ReadLine();

            while (inputLine != "I'm your Huckleberry")
            {
                var parts = inputLine
                    .Split();

                if (parts[0] != "talk")
                {
                    FindAndAddCorrectAnimal(dogDict, catDict, snakeDict, parts);
                }
                else
                {
                    bool isADogName = dogDict.ContainsKey(parts[1]);
                    bool isACatName = catDict.ContainsKey(parts[1]);
                    bool isASnakeName = snakeDict.ContainsKey(parts[1]);

                    HandleTalking(dogDict, catDict, snakeDict, parts, isADogName, isACatName, isASnakeName);
                }
                inputLine = Console.ReadLine();
            }

            dogDict.ToList().ForEach(x => Console.WriteLine("Dog: {0}, Age: {1}, Number Of Legs: {2}",
                x.Value.Name,
                x.Value.Age,
                x.Value.NumberOfLegs
                ));

            catDict.ToList().ForEach(x => Console.WriteLine("Cat: {0}, Age: {1}, IQ: {2}",
                x.Value.Name,
                x.Value.Age,
                x.Value.IntelligenceQuotient
                ));

            snakeDict.ToList().ForEach(x => Console.WriteLine("Snake: {0}, Age: {1}, Cruelty: {2}",
                x.Value.Name,
                x.Value.Age,
                x.Value.CrueltyCoefficient));
        }

        public static void HandleTalking(Dictionary<string, Dog> dogDict, Dictionary<string, Cat> catDict, Dictionary<string, Snake> snakeDict, string[] parts, bool isADogName, bool isACatName, bool isASnakeName)
        {
            if (isADogName)
            {
                Console.WriteLine(dogDict[parts[1]].Talk());
            }
            else if (isACatName)
            {
                Console.WriteLine(catDict[parts[1]].Talk());
            }
            else if (isASnakeName)
            {
                Console.WriteLine(snakeDict[parts[1]].Talk());
            }
            else
            {
                throw new Exception("Can not find name in any Dictionaries");
            }
        }

        public static void FindAndAddCorrectAnimal(Dictionary<string, Dog> dogDict, Dictionary<string, Cat> catDict, Dictionary<string, Snake> snakeDict, string[] parts)
        {
            //Find Based on the Name
            switch (parts[0])
            {
                case "Dog":
                    dogDict.Add(parts[1], new Dog()
                    {
                        Name = parts[1],
                        Age = int.Parse(parts[2]),
                        NumberOfLegs = int.Parse(parts[3])
                    });
                    break;

                case "Cat":
                    catDict.Add(parts[1], new Cat()
                    {
                        Name = parts[1],
                        Age = int.Parse(parts[2]),
                        IntelligenceQuotient = int.Parse(parts[3])
                    });
                    break;

                case "Snake":
                    snakeDict.Add(parts[1], new Snake()
                    {
                        Name = parts[1],
                        Age = int.Parse(parts[2]),
                        CrueltyCoefficient = int.Parse(parts[3])
                    });
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
