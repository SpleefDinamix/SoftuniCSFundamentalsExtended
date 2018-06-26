using System;

namespace Boxes
{
    public class Box
    {
        public int[] TopLeftPoint { get; set; }
        public int[] TopRightPoint { get; set; }
        public int[] BottomLeftPoint { get; set; }
        public int[] BottomRightPoint { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public void CalculateWidth()
        {
            Width = Math.Abs(TopLeftPoint[0] - TopRightPoint[0]);
        }

        public void CalculateHeight()
        {
            Height = Math.Abs(TopLeftPoint[1] - BottomLeftPoint[1]);
        }

        public int CalculatePerimeter()
        {
            return 2 * Width + 2 * Height;
        }

        public int CalculateArea()
        {
            return Width * Height;
        }
    }
}
