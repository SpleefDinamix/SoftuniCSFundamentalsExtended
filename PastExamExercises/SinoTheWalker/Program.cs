using System;

namespace SinoTheWalker
{
    public class Program
    {
        public static void Main()
        {
            var startTime = TimeSpan.Parse(Console.ReadLine());
            int steps = int.Parse(Console.ReadLine());
            int secondsPerStep = int.Parse(Console.ReadLine());

            int secondsInADay = 24 * 60 * 60;
            int totalSecondsNeeded = (int)(((double)secondsPerStep * steps) % secondsInADay);
            var endTime = startTime.Add(new TimeSpan(0, 0, totalSecondsNeeded));
            Console.WriteLine("Time Arrival: " + endTime.ToString(@"hh\:mm\:ss"));
        }
    }
}
