using System;
using System.IO;
using Common;

namespace Day02
{
    public class Part1 : IPart<string>
    {
        public string Solve()
        {
            var input = File.ReadAllText("input1.txt");
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var x = 0;
            var y = 0;
            var result = "";
            foreach (var line in lines)
            {
                foreach (var ch in line)
                {
                    if (ch == 'U')
                    {
                        y--;
                        if (y < -1)
                        {
                            y++;
                        }
                    }
                    else if (ch == 'D')
                    {
                        y++;
                        if (y > 1)
                        {
                            y--;
                        }
                    }
                    else if (ch == 'L')
                    {
                        x--;
                        if (x < -1)
                        {
                            x++;
                        }
                    }
                    else if (ch == 'R')
                    {
                        x++;
                        if (x > 1)
                        {
                            x--;
                        }
                    }
                }
                result += GetNumberByCoords(x, y);
            }
            return result;
        }

        int GetNumberByCoords(int x, int y)
        {
            return (x + 2) + (y + 1)*3;
        }
    }
}