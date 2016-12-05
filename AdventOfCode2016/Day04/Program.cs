using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            var solve1 = new Part1().Solve();
            Console.WriteLine(solve1);
            // > 4910, > 9873
            //var solve2 = new Part2().Solve();
            //Console.WriteLine(solve2);
        }
    }

    public class Part1:IPart<int>
    {
        public int Solve()
        {
            var input = File.ReadAllLines("input1.txt");
            input = new[] { "aaaaa-bbb-z-y-x-123[abxyz]" };
            var idSum = 0;
            foreach (var line in input)
            {

                var isReal = CheckRoomIsReal(line);
                Console.WriteLine(isReal);
                if (isReal)
                {
                    idSum += GetSectorId(line);

                }
            }
            return idSum;
        }

        private static bool CheckRoomIsReal(string line)
        {
            var checkSum = line.Substring(line.LastIndexOf("[")+1, 5);
            var lastDashPos = line.LastIndexOf('-');
            var roomNames = line.Substring(0, lastDashPos);
            var roomNameLetters = roomNames.Replace("-", "")
                .ToCharArray()
                .GroupBy(x => x)
                .OrderByDescending(g => g.Count())
                .ToDictionary(x => x.Key, x => x.Count());
            //.Select(x => new { Letter = x.Key, Count =x.Count()})
            //.ToArray();

            foreach (var letter in checkSum)
            {
                int count;
                if (!roomNameLetters.TryGetValue(letter, out count ))
                {
                    return false;
                }
                var moreCount = roomNameLetters.Count(x => x.Value > count);
                if (moreCount > 4)
                {
                    return false; // not real
                }
            }
            return true;
        }

        private static int GetSectorId(string line)
        {
            var lastDashPos = line.LastIndexOf('-');
            var idLength = line.IndexOf("[", lastDashPos, StringComparison.Ordinal) - lastDashPos - 1;
            var idStr = line.Substring(lastDashPos + 1, idLength);
            var id = int.Parse(idStr);
            return id;
        }
    }

    public class Room
    {
        string _name;

        private readonly int _sectorId;

        public int SectorId { get; private set; }

        public Room(string name, int sectorId)
        {
            _name = name;
            _sectorId = sectorId;
        }
    }
}
