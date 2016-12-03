using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            new Part1().Run();
        }
    }

    internal class Part1
    {
        public void Run()
        {
            var lines = File.ReadAllLines("input1.txt");
            var counter = 0;
            foreach (var line in lines)
            {
                var orderedSides = line
                    .Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
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
}
