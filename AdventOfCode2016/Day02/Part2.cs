using System;
using System.IO;
using Common;

namespace Day02
{
    public class Part2 : IPart<string>
    {
        public string Solve()
        {
            var input = File.ReadAllText("input1.txt");
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //    1
            //  2 3 4
            //5 6 7 8 9
            //  A B C
            //    D
            // start at "5"
            var x = -2;
            var y = 0;

            var result = "";
            foreach (var line in lines)
            {
                foreach (var ch in line)
                {
                    if (ch == 'U')
                    {
                        y--;
                        if (Math.Abs(x) + Math.Abs(y) > 2)
                        {
                            y++;
                        }
                    }
                    else if (ch == 'D')
                    {
                        y++;
                        if (Math.Abs(x) + Math.Abs(y) > 2)
                        {
                            y--;
                        }
                    }
                    else if (ch == 'L')
                    {
                        x--;
                        if (Math.Abs(x) + Math.Abs(y) > 2)
                        {
                            x++;
                        }
                    }
                    else if (ch == 'R')
                    {
                        x++;
                        if (Math.Abs(x) + Math.Abs(y) > 2)
                        {
                            x--;
                        }
                    }
                }
                result = GetNumberByCoords(x, y);
            }
            return result;
        }

        string GetNumberByCoords(int x, int y)
        {
            string[] template = new string[]
            {
                "  1  ",
                " 234 ",
                "56789",
                " ABC ",
                "  D  ",
            };
            return template[y + 2][x + 2].ToString();
        }
    }
}