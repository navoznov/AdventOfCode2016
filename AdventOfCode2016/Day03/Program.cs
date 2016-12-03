using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            new Part1().Run();
            new Part2().Run();
        }
    }

    internal class Part1
    {
        public void Run()
        {
            var lines = File.ReadAllLines("input1.txt");
            var counter = 0;
            var separator = new [] { ' ' };
            foreach (var line in lines)
            {
                var orderedSides = line
                    .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .OrderByDescending(x => x)
                    .ToArray();
                if (orderedSides[0]<orderedSides[1]+orderedSides[2])
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }

    internal class Part2
    {
        public void Run()
        {
            var input = File.ReadAllLines("input1.txt");
            var counter = 0;
            var separator = new [] { ' ' };
            for (var i = 0; i < input.Length; i+=3)
            {
                var nine = Enumerable.Range(0,3)
                    .Select(j => input[i+j]
                        .Split(separator,StringSplitOptions.RemoveEmptyEntries)
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
            Console.WriteLine(counter);
        }
    }
}
