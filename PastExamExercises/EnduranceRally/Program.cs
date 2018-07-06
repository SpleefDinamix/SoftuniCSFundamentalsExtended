using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace EnduranceRally
{
    public class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var racers = Console.ReadLine().Split();
            var zones = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            var checkPoints = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            foreach (string racer in racers)
            {
                double racerFuel = racer[0];
                int reachedZone = 0;

                for (int z = 0; z < zones.Length; z++)
                {
                    if (checkPoints.Contains(z))
                    {
                        reachedZone++;
                        racerFuel += zones[z];
                    }
                    else
                    {
                        if (racerFuel - zones[z] <= 0)
                        {
                            racerFuel -= zones[z];
                            break;
                        }
                        else
                        {
                            reachedZone++;
                            racerFuel -= zones[z];
                        }
                    }
                }

                if (racerFuel > 0)
                {
                    Console.WriteLine("{0} - fuel left {1:F2}", racer, racerFuel);
                }
                else
                {
                    Console.WriteLine($"{racer} - reached {reachedZone}");
                }
                
            }
        }
    }
}
