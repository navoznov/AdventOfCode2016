using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Common;

namespace Day07
{
    public class Part2:IPart<int>
    {
        public int Solve()
        {
            var lines = File.ReadAllLines("input1.txt");
            return lines.Count(IsSupportTls);
        }

        private bool IsSupportTls(string line)
        {
            var parts = line.Split('[', ']');
            var abaList = new List<string>();
            var babList = new List<string>();
            for (var i = 0; i < parts.Length; i++)
            {
                var part = parts[i];
                var currentList = i%2 == 0 ? abaList : babList;
                var abaString = GetAbaStrings(part);
                currentList.AddRange(abaString);
            }
            return babList.Select(InvertBab).Intersect(abaList).Any();
        }

        IEnumerable<string> GetAbaStrings(string str)
        {
            for (var i = 0; i < str.Length-2; i++)
            {
                if (str[i]==str[i+2] && str[i]!=str[i+1])
                {
                    yield return str.Substring(i, 3);
                }
            }
        }

        string InvertBab(string str)
        {
            return new StringBuilder().Append(str[1]).Append(str[0]).Append(str[1]).ToString();
        }
    }
}