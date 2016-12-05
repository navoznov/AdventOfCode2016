using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            var solve1 = new Part1().Solve();
            Console.WriteLine(solve1);
            var solve2 = new Part2().Solve();
            Console.WriteLine(solve2);
        }
    }
}
