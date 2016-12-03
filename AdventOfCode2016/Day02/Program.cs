using System;
using System.IO;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            new Part1().Run();
            new Part2().Run();
        }

    }

    public class Part1
    {
        public void Run()
        {
            var input = File.ReadAllText("input1.txt");
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var x = 0;
            var y = 0;

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
                Console.Write(GetNumberByCoords(x, y));
            }
            Console.WriteLine();
        }

        int GetNumberByCoords(int x, int y)
        {
            return (x + 2) + (y + 1)*3;
        }

    }
    public class Part2
    {
        public void Run()
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

            foreach (var line in lines)
            {
                foreach (var ch in line)
                {
                    if (ch == 'U')
                    {
                        y--;
                        if (Math.Abs(x)+Math.Abs(y) >2)
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
                    else if (ch=='R')
                    {
                        x++;
                        if (Math.Abs(x) + Math.Abs(y) > 2)
                        {
                            x--;
                        }
                    }
                }
                Console.Write(GetNumberByCoords(x, y));
            }
            Console.WriteLine();
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
            return template[y+2][x+2].ToString();
        }

    }
}