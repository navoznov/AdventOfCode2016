using System;
using System.IO;
using System.Linq;
using System.Text;
using Common;

namespace Day06
{
    public class Part2 : IPart<string>
    {
        public string Solve()
        {
            var input = GetInput();
            var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            int messageLength = lines[0].Length;
            const int abcLength = 26;
            var counterList = Enumerable.Range(0, messageLength).Select(n => Enumerable.Range('a', abcLength).ToDictionary(x => (char)x, x => 0)).ToList();

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var j = 0; j < messageLength; j++)
                {
                    var ch = line[j];
                    counterList[j][ch]++;
                }
            }

            var sb = new StringBuilder();
            for (var i = 0; i < counterList.Count; i++)
            {
                sb.Append(counterList[i].OrderBy(x => x.Value).First().Key);
            }
            return sb.ToString();
        }

        string GetInput()
        {
            return File.ReadAllText("input1.txt");
        }
    }
}