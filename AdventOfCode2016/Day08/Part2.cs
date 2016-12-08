using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Common;

namespace Day08
{
    public class Part2 : IPart<string>
    {
        public string Solve()
        {
            const int width = 50;
            const int height = 6;
            var screen = new Screen(width, height);
            var lines = File.ReadAllLines("input1.txt");
            var rotateRegex = new Regex(@"rotate (\w+) \w=(\d+) by (\d+)");
            foreach (var line in lines)
            {
                if (line.StartsWith("rect"))
                {
                    var measures = line.Substring(5).Split('x').Select(int.Parse).ToArray();
                    screen.Rect(measures[0], measures[1]);
                }
                else
                {
                    var match = rotateRegex.Match(line);
                    var direction = match.Groups[1].Value;
                    var index = int.Parse(match.Groups[2].Value);
                    var shiftsCount = int.Parse(match.Groups[3].Value);
                    if (direction == "row")
                    {
                        screen.RotateRight(index, shiftsCount);
                    }
                    else
                    {
                        screen.RotateDown(index, shiftsCount);
                    }
                }
            }

            var sb = new StringBuilder();
            for (var j = 0; j < screen.Height; j++)
            {
                for (var i = 0; i < screen.Width; i++)
                {
                    sb.Append(screen.Grid[i, j] ? "X" : " ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

    }
}