using System;
using System.Linq;

namespace Japanese_Roulette
{
    public class Program
    {
        public static void Main()
        {
            int[] cylinder = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int muzzle = 2;
            int bulletPosition = Array.IndexOf(cylinder,1);

            string outputMessage = "Everybody got lucky!";

            string[] players = Console.ReadLine()
                .Split();

            for (int i = 0; i < players.Length; i++)
            {
                string [] playerStats = players[i].Split(',');

                int strenght = int.Parse(playerStats[0]);
                string direction = playerStats[1];

                switch (direction)
                {
                    case "Left":
                        bulletPosition = (bulletPosition - strenght) % cylinder.Length;
                        if (bulletPosition < 0)
                        {
                            bulletPosition += cylinder.Length;
                        }
                        break;

                    case "Right":
                        bulletPosition = (bulletPosition + strenght) % cylinder.Length;
                        break;
                }

                if (bulletPosition == muzzle)
                {
                    outputMessage = $"Game over! Player {i} is dead.";
                    break;
                }

                bulletPosition++;

            }

            Console.WriteLine(outputMessage);

        }
    }
}
