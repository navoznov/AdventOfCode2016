using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input1.txt");
            var lines = input.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            var startPoint = new Point(0, 0);

            var runner = new Runner(startPoint);
            var path = new List<Point> { startPoint };
            Point firstAlreadyVisitedPoint = null; // for part 2

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                TurnDirection direction;
                int stepsCount;
                ParseInstruction(line, out direction, out stepsCount);

                runner.Turn(direction);
                for (var j = 0; j < stepsCount; j++)
                {
                    runner.Go();
                    var currentPosition = runner.GetPoint();
                    if (firstAlreadyVisitedPoint == null && CheckTwiceVisitedPoints(path, currentPosition))
                    {
                        firstAlreadyVisitedPoint = currentPosition;
                    }
                    path.Add(currentPosition);
                }
            }
            Console.WriteLine(runner.GetPoint().GetDistanceTo(startPoint));
            Console.WriteLine(startPoint.GetDistanceTo(firstAlreadyVisitedPoint));
        }

        private static void ParseInstruction(string line, out TurnDirection direction, out int stepsCount)
        {
            direction = line[0] == 'R' ? TurnDirection.Right : TurnDirection.Left;
            stepsCount = int.Parse(line.Substring(1));
        }

        private static bool CheckTwiceVisitedPoints(List<Point> path, Point point)
        {
            return path.Any(p => p.X == point.X && p.Y == point.Y);
        }
    }

    public class Runner
    {
        protected bool _forward;

        protected bool _xAxis;

        public Runner(Point point)
        {
            _forward = true;
            _xAxis = false;
            X = point.X;
            Y = point.Y;
        }

        public Point GetPoint()
        {
            return new Point(X, Y);
        }

        public int X { get; protected set; }

        public int Y { get; protected set; }

        public void Turn(TurnDirection turnDirection)
        {
            if (_xAxis && turnDirection == TurnDirection.Right || !_xAxis && turnDirection == TurnDirection.Left)
            {
                _forward = !_forward;
            }
            _xAxis = !_xAxis;
        }

        public virtual void Go(int steps = 1)
        {
            if (_xAxis)
            {
                X = X + (_forward ? steps : -steps);
            }
            else
            {
                Y = Y + (_forward ? steps : -steps);
            }
        }

        public int GetDistanceTo(int x, int y)
        {
            return Math.Abs(X - x) + Math.Abs(Y - y);
        }
    }

    public enum TurnDirection
    {
        Left,

        Right,
    }

    public class Point
    {
        public int X { get; private set; }

        public int Y { get; private set; }

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