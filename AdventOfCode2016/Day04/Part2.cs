using System;
using System.IO;
using System.Text;
using Common;

namespace Day04
{
    public class Part2 : IPart<int>
    {
        public int Solve()
        {
            var input = File.ReadAllLines("input1.txt");
            var idSum = 0;
            foreach (var line in input)
            {
                var sectorId = GetSectorId(line);
                var lastDashPos = line.LastIndexOf('-');
                var roomName = line.Substring(0, lastDashPos);
                var decryptedRoomName = ApplyCaesarCipher(roomName, sectorId);
                if (decryptedRoomName.Contains("north") && decryptedRoomName.Contains("pole"))
                {
                    return sectorId;
                }
            }
            return idSum;
        }

        string ApplyCaesarCipher(string str, int shift)
        {
            var englishAlphabetSize = 26;
            var realShift = shift%englishAlphabetSize;
            var sb = new StringBuilder();
            foreach (var letter in str)
            {
                if (letter < 'a' || letter > 'z')
                {
                    sb.Append(' ');
                    continue;
                }
                var encryptedLetter = (char)((letter - 'a' + realShift)%englishAlphabetSize + 'a');
                sb.Append(encryptedLetter);
            }
            return sb.ToString();
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
}