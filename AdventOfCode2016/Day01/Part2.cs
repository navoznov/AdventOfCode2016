using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common;

namespace Day01
{
    internal class Part2 : IPart<int>
    {
        public int Solve()
        {
            var lines = File.ReadAllText("input1.txt").Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var startPoint = new Point(0, 0);

            var path = new List<Point> { startPoint };
            var direction = 0;  // количество повопротов направо на 90 градусов (относительно направления на север)
            var x = 0;
            var y = 0;
            foreach (var line in lines)
            {
                direction += line[0] == 'R' ? 1 : 3;    // один повопрот влево равен трем поворотам вправо
                direction = direction%4;

                var stepsCount = int.Parse(line.Substring(1));
                    
                for (var j = 0; j < stepsCount; j++)
                {
                    var increment = direction < 2 ? 1 : -1;

                    if (direction % 2 == 0)
                    {
                        y += increment;
                    }
                    else
                    {
                        x += increment;
                    }
                    var current = new Point(x,y);
                    if (path.Any(point => point.X == current.X && point.Y == current.Y))
                    {
                        return current.GetDistanceTo(startPoint);
                    }
                    path.Add(current);
                }
            }
            return -1;
        }
    }
}