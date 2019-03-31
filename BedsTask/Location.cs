using System;

namespace BedsTask
{
    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Location(int x, int y)
        {
            if (x < 0 || y < 0)
                throw new ArgumentException();

            X = x;
            Y = y;
        }
    }
}
