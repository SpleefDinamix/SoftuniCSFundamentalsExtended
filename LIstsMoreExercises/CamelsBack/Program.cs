using System;
using System.Linq;


namespace CamelsBack
{
    public class Program
    {
        public static void Main()
        {
            var buildings = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var camelsBack = int.Parse(Console.ReadLine());
            int rounds = 0;

            while(buildings.Count != camelsBack)
            {
                rounds++;
                buildings.RemoveAt(0);
                buildings.RemoveAt(buildings.Count-1);
            }

            Console.WriteLine(rounds!=0? $"{rounds} rounds" 
                + Environment.NewLine + $"remaining: {String.Join(" ",buildings)}"
                : $"already stable: {String.Join(" ",buildings)}");
        }
    }
}
