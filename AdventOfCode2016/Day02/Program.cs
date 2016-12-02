using System;
using System.IO;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
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
                Console.Write(GetNumberByCoords(x,y));
            }
            Console.WriteLine();
        }

        static int GetNumberByCoords(int x, int y)
        {
            return (x + 2) + (y + 1)*3;
        }
    }
}