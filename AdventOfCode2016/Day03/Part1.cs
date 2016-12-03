using System;
using System.IO;
using System.Linq;
using Common;

namespace Day03
{
    internal class Part1 : IPart<int>
    {
        public int Solve()
        {
            var lines = File.ReadAllLines("input1.txt");
            var counter = 0;
            var separator = new[] { ' ' };
            foreach (var line in lines)
            {
                var orderedSides = line
                    .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .OrderByDescending(x => x)
                    .ToArray();
                if (orderedSides[0] < orderedSides[1] + orderedSides[2])
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}