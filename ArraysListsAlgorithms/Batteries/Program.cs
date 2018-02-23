using System;
using System.Linq;

namespace Batteries
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var capacities = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            var usagePerHour = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            int hours = int.Parse(Console.ReadLine());

            var batteryUsage = capacities.Take(capacities.Length).ToArray();

            StressBatteries(batteryUsage, usagePerHour, hours);
            PrintResults(capacities, batteryUsage);
        }

        private static void PrintResults(double[] capacities, double[] batteryUsage)
        {
            for (int i = 0; i < capacities.Length; i++)
            {
                var currentBattery = i + 1;
                double percentageLeft = 100 / capacities[i] * batteryUsage[i];
                string output1 = $"Battery {currentBattery}: {batteryUsage[i]:F2} mAh ({percentageLeft:F2})%";
                string output2 = $"Battery {currentBattery}: dead (lasted {Math.Abs(batteryUsage[i])} hours)";

                //Finding if it's the capacity of the battery or the time when battery died.
                //if capacity => percentageLeft, else if time of death => convert the -time to +time;

                string result = batteryUsage[i] > 0 ? output1 : output2;
                Console.WriteLine(result);
            }
        }

        private static void StressBatteries(double[] batteryUsage, double[] usagePerHour, int hours)
        {
            int cycle = 1;

            while (cycle <= hours)
            {
                for (int i = 0; i < batteryUsage.Length; i++)
                {
                    if (batteryUsage[i] - usagePerHour[i] > 0)
                    {
                        batteryUsage[i] -= usagePerHour[i];
                    }
                    else if(batteryUsage[i] > 0)
                    {
                        // Storing the cycles as negative time
                        batteryUsage[i] = -1 * cycle;
                    }
                }

                cycle++;
            }

        }
    }
}
