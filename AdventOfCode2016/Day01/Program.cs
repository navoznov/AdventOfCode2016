using System;
using System.IO;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input1.txt");
            var lines = input.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            var runner = new Runner();
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                TurnDirection direction;
                int stepsCount;
                ParseInstruction(line, out direction, out stepsCount);

                runner.Turn(direction);
                runner.Go(stepsCount);
            }

            Console.WriteLine(runner.GetDistanceTo(0,0));
        }

        private static void ParseInstruction(string line, out TurnDirection direction, out int stepsCount)
        {
            direction = line[0] == 'R' ? TurnDirection.Right : TurnDirection.Left;
            stepsCount = int.Parse(line.Substring(1));
        }
    }

    public class Runner
    {
        private int[] _steps;

        private bool _forward;

        private bool _xAxis;

        private int _x;

        private int _y;

        public Runner()
        {
            _steps = new int[4];
            _forward = true;
            _xAxis = false;
            _x = 0;
            _y = 0;
        }

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public void Turn(TurnDirection turnDirection)
        {
            if (_xAxis && turnDirection == TurnDirection.Right || !_xAxis && turnDirection==TurnDirection.Left)
            {
                _forward = !_forward;
            }
            _xAxis = !_xAxis;
        }

        public void Go(int steps)
        {
            if (_xAxis)
            {
                _x = _x + (_forward ? steps : -steps);
            }
            else
            {
                _y = _y + (_forward ? steps : -steps);
            }
        }

        public int GetDistanceTo(int x, int y)
        {
            return Math.Abs(_x - x) + Math.Abs(_y - y);
        }
    }

    public enum TurnDirection
    {
        Left,

        Right,
    }
}