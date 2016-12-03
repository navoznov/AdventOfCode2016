using System;

namespace Day01
{
    public class Point
    {
        public int X { get; protected set; }

        public int Y { get; protected set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int GetDistanceTo(Point point)
        {
            return Math.Abs(X - point.X) + Math.Abs(Y - point.Y);
        }
    }
}