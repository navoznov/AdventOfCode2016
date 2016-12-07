using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Common;

namespace Day07
{
    public class Part1 : IPart<int>
    {
        public int Solve()
        {
            var lines = File.ReadAllLines("input1.txt");
            return lines.Count(IsSupportTls);
        }

        private bool IsSupportTls(string line)
        {
            var parts = line.Split('[', ']');
            var hasAbba = false;
            for (var i = 0; i < parts.Length; i++)
            {
                var part = parts[i];
                if (i%2 == 0)
                {
                    if (!hasAbba)
                    {
                        hasAbba = CheckAbba(part);
                    }
                }
                else if (CheckAbba(part))
                {
                    return false;
                }
            }
            return hasAbba;
        }

        bool CheckAbba(string str)
        {
            var abbaRegex = new Regex(@"((\w)(\w)\3\2)");
            var match = abbaRegex.Match(str);
            if (!match.Success)
            {
                return false;
            }
            var value = match.Groups[0].Value;
            return value[0] != value[1];
        }
    }
}