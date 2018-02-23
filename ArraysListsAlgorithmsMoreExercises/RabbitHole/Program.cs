using System;
using System.Collections.Generic;
using System.Linq;

namespace RabbitHole
{
    public class Program
    {
        public static void Main()
        {
            var commands = Console.ReadLine().Split().ToList();
            int energy = int.Parse(Console.ReadLine());
            int playerPosition = 0;

            string result = FindTheHole(commands,ref playerPosition,ref energy);
            Console.WriteLine(result);
        }

        public static string FindTheHole(List<string> commands,ref int playerPosition,ref int energy)
        {
            string outputMessage = String.Empty;
            bool lastBomb = false;

            while (energy > 0)
            {
                lastBomb = false;
                string[] commandParts = commands[playerPosition].Split('|');
                string instructionPart = commandParts.First();

                if (instructionPart == "RabbitHole")
                {
                    outputMessage = "You have 5 years to save Kennedy!";
                    break;
                }

                int stepsToGoPart = int.Parse(commandParts.Last());
                
                switch (instructionPart)
                {
                    case "Left":
                        playerPosition = Math.Abs(playerPosition - stepsToGoPart) % commands.Count;
                        energy -= stepsToGoPart;
                        break;

                    case "Right":
                        playerPosition = (playerPosition + stepsToGoPart) % commands.Count;
                        energy -= stepsToGoPart;
                        break;

                    case "Bomb":
                        commands.RemoveAt(playerPosition);
                        playerPosition = 0;
                        energy -= stepsToGoPart;
                        lastBomb = true;
                        break;
                }

                if (commands.Last() != "RabbitHole")
                {
                    commands.RemoveAt(commands.Count - 1);
                }
                commands.Add($"Bomb|{energy}");

            }

            if (energy <= 0 && lastBomb)
            {
                outputMessage = "You are dead due to bomb explosion!";
            }
            else if(energy <=0 && !lastBomb)
            {
                outputMessage = "You are tired. You can't continue the mission.";
            }

            return outputMessage;

        }
    }
}
