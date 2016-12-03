using System;
using System.IO;
using Common;

namespace Day01
{
    public class Part1 : IPart<int>
    {
        public int Solve()
        {
            var lines = File.ReadAllText("input1.txt").Split(new[] {',',' ' }, StringSplitOptions.RemoveEmptyEntries);

            var result = 0;
            // количество поворотов направо. 0 == —евер
            int direction = 0;

            foreach (var line in lines)
            {
                var turn = line[0];
                var steps = int.Parse(line.Substring(1));

                direction += turn == 'R' ? 1 : 3;
                direction = direction%4;
                
                result += (direction < 2 ? steps : -steps);
            }
            return result;
        }
    }
}