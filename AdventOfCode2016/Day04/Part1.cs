using System;
using System.IO;
using System.Linq;
using System.Text;
using Common;

namespace Day04
{
    public class Part1 : IPart<int>
    {
        public int Solve()
        {
            var input = File.ReadAllLines("input1.txt");
            var idSum = 0;
            foreach (var line in input)
            {
                var isReal = CheckRoomIsReal(line);
                if (isReal)
                {
                    idSum += GetSectorId(line);
                }
            }
            return idSum;
        }

        private bool CheckRoomIsReal(string line)
        {
            var checkSum = line.Substring(line.LastIndexOf("[") + 1, 5);
            var lastDashPos = line.LastIndexOf('-');
            var roomName = line.Substring(0, lastDashPos);
            var roomNameLetters = roomName.Replace("-", "")
                .ToCharArray()
                .GroupBy(x => x)
                .OrderByDescending(g => g.Count())
                .ThenBy(x => x.Key)
                .Select(x => x.Key)
                .Take(5)
                .ToArray();

            return !roomNameLetters.Except(checkSum).Any();
        }

        private int GetSectorId(string line)
        {
            var lastDashPos = line.LastIndexOf('-');
            var idLength = line.IndexOf("[", lastDashPos, StringComparison.Ordinal) - lastDashPos - 1;
            var idStr = line.Substring(lastDashPos + 1, idLength);
            var id = int.Parse(idStr);
            return id;
        }
    }
}