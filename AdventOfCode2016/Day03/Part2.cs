using System;
using System.IO;
using System.Linq;
using Common;

namespace Day03
{
    internal class Part2 : IPart<int>
    {
        public int Solve()
        {
            var input = File.ReadAllLines("input1.txt");
            var counter = 0;
            var separator = new[] { ' ' };
            for (var i = 0; i < input.Length; i += 3)
            {
                var nine = Enumerable.Range(0, 3)
                    .Select(j => input[i + j]
                        .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray())
                    .ToArray();

                for (var j = 0; j < 3; j++)
                {
                    var triangle = Enumerable.Range(0, 3).Select(k => nine[k][j]).OrderByDescending(x => x).ToArray();
                    if (triangle[0] < triangle[1] + triangle[2])
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
    }
}