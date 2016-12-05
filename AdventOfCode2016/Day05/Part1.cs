using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Common;

namespace Day05
{
    public class Part1 : IPart<string>
    {
        public string Solve()
        {
            var pass = GetInput();
            const int digits = 8;
            var sb = new StringBuilder(digits);
            var index = 0;
            for (var i = 0; i < digits; i++)
            {
                string hash;
                do
                {
                    index++;
                    hash = Md5Hasher.GetMd5Hash(pass + index);
                    if(hash.StartsWith("00000"))
                        break;
                } while (true);

                var letter = hash[5];
                sb.Append(letter);
                Console.WriteLine($"{letter} - {index}");
            }
            return sb.ToString();
        }

        public string GetInput()
        {
            return File.ReadAllText("input1.txt");
        }
    }
}