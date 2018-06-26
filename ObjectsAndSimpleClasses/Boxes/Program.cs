using System;
using System.Collections.Generic;
using System.Linq;

namespace Boxes
{
    public class Program
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var boxes = new List<Box>();

            while (inputLine != "end")
            {
                var points = inputLine
                    .Split(new[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var coords = new List<int[]>();
                foreach (var point in points)
                {
                    coords.Add(point
                        .Split(':')
                        .Select(int.Parse)
                        .ToArray());
                }

                boxes.Add(new Box()
                {
                    TopLeftPoint = coords[0],
                    TopRightPoint = coords[1],
                    BottomLeftPoint = coords[2],
                    BottomRightPoint = coords[3]
                });
                inputLine = Console.ReadLine(); 
            }

            foreach (var box in boxes)
            {
                box.CalculateWidth();
                box.CalculateHeight();

                Console.WriteLine("Box: {0}, {1}", box.Width, box.Height);
                Console.WriteLine("Perimeter: {0}",box.CalculatePerimeter());
                Console.WriteLine("Area: {0}",box.CalculateArea());
            }
        }
    }
}
