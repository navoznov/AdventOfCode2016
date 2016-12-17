using System.IO;
using Common;

namespace Day09
{
    internal class Part1 : IPart<int>
    {
        public int Solve()
        {
            var input = File.ReadAllText("input1.txt");
            //input = @"(8x2)(2x3)ABCD";            // 15
            //input = @"AAA(14x3)(3x2)ABCDEFGHIJ";  // 40
            //input = @"A(2x2)BCD(2x2)EFG";         // 11
            //input = @"(6x1)(1x3)A";               // 6
            //input = @"X(8x2)(3x3)ABCY";           // 18

            return GetDecompressedStringLength(input);
        }

        int GetDecompressedStringLength(string str)
        {
            int counter = 0;
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
                counter += openBracePos + lettersToRepeatCount*repeatCount;
                str = str.Substring(closeBracePos + lettersToRepeatCount + 1);
            }
        }
    }
}