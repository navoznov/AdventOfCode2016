using System;
using System.IO;
using Common;

namespace Day09
{
    internal class Part2 : IPart<long>
    {
        public long Solve()
        {
            var input = File.ReadAllText("input1.txt");
            return GetDecompressedStringLength(input);
        }

        long GetDecompressedStringLength(string str)
        {
            long counter = 0;
            while (true)
            {
                var openBracePos = str.IndexOf('(');
                if (openBracePos == -1)
                {
                    return counter + str.Length;
                }
                var closeBracePos = str.IndexOf(')');

                var markerStr = str.Substring(openBracePos + 1, closeBracePos - openBracePos - 1);
                var markerParts = markerStr.Split('x');
                var lettersToRepeatCount = int.Parse(markerParts[0]);
                var repeatCount = int.Parse(markerParts[1]);

                if (openBracePos == str.LastIndexOf('('))
                {
                    return counter + lettersToRepeatCount*repeatCount + (str.Length - markerStr.Length - 2 - lettersToRepeatCount);
                }

                counter += openBracePos;

                var repeatableStr = str.Substring(closeBracePos + 1, lettersToRepeatCount);
                counter += GetDecompressedStringLength(repeatableStr)*repeatCount;

                Program.TotalCounter++;
                if (Program.TotalCounter%100000 == 0)
                {
                    Console.WriteLine($"{Program.TotalCounter} - {counter} - {str.Length}");
                }

                str = str.Substring(closeBracePos + lettersToRepeatCount + 1);
            }
        }
    }
}