using System;

namespace Day09
{
    class Program
    {
        public static long TotalCounter = 0;

        static void Main(string[] args)
        {
            var solve1 = new Part1().Solve();
            Console.WriteLine(solve1);

            var solve2 = new Part2().Solve();
            Console.WriteLine(solve2);
        }
    }
}