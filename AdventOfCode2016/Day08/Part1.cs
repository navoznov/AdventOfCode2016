using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Common;

namespace Day08
{
    public class Part1 : IPart<int>
    {
        public int Solve()
        {
            const int width = 50;
            const int height = 6;
            var screen = new Screen(width, height);
            var lines = File.ReadAllLines("input1.txt");
            var rotateRegex = new Regex(@"rotate (\w+) \w=(\d+) by (\d+)");
            foreach (var line in lines)
            {
                if (line.StartsWith("rect"))
                {
                    var measures = line.Substring(5).Split('x').Select(int.Parse).ToArray();
                    screen.Rect(measures[0], measures[1]);
                }
                else
                {
                    var match = rotateRegex.Match(line);
                    var direction = match.Groups[1].Value;
                    var index = int.Parse(match.Groups[2].Value);
                    var shiftsCount = int.Parse(match.Groups[3].Value);
                    if (direction == "row")
                    {
                        screen.RotateRight(index, shiftsCount);
                    }
                    else
                    {
                        screen.RotateDown(index, shiftsCount);
                    }
                }
            }

            var counter = 0;
            for (var i = 0; i < screen.Width; i++)
            {
                for (var j = 0; j < screen.Height; j++)
                {
                    if (screen.Grid[i, j])
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        public class Screen
        {
            public Screen(int width, int height)
            {
                Width = width;
                Height = height;
                Grid = new bool[Width, Height];
            }

            public int Width { get; private set; }

            public int Height { get; private set; }

            public bool[,] Grid { get; private set; }

            public void Rect(int a, int b)
            {
                for (var i = 0; i < a; i++)
                {
                    for (var j = 0; j < b; j++)
                    {
                        Grid[i, j] = true;
                    }
                }
            }

            public void RotateRight(int row, int shiftsCount)
            {
                shiftsCount = shiftsCount%Width;
                var tempRow = new bool[Width];

                for (var i = 0; i < Width; i++)
                {
                    var current = Grid[i, row];
                    var newIndex = (i + shiftsCount)%Width;
                    tempRow[newIndex] = current;
                }

                for (var i = 0; i < Width; i++)
                {
                    Grid[i, row] = tempRow[i];
                }
            }

            public void RotateDown(int column, int shiftsCount)
            {
                shiftsCount = shiftsCount%Height;
                var tempRow = new bool[Height];

                for (var i = 0; i < Height; i++)
                {
                    var current = Grid[column, i];
                    var newIndex = (i + shiftsCount)%Height;
                    tempRow[newIndex] = current;
                }

                for (var i = 0; i < Height; i++)
                {
                    Grid[column, i] = tempRow[i];
                }
            }
        }
    }
}