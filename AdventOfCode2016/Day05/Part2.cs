using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Common;

namespace Day05
{
    public class Part2 : IPart<string>
    {
        public string Solve()
        {
            var pass = GetInput();
            const int digits = 8;
            var list = Enumerable.Range(0, digits).Select(x => (string)null).ToList();
            var index = 0;
            string hash;
            int position;
            do
            {
                index++;
                hash = Md5Hasher.GetMd5Hash(pass + index);
                if (!hash.StartsWith("00000"))
                {
                    continue;
                }

                if (!int.TryParse(hash.Substring(5, 1), out position))
                {
                    continue;
                }
                if (position >= digits)
                {
                    continue;
                }
                if (list[position] != null)
                {
                    continue;
                }

                var letter = hash.Substring(6, 1);
                list[position] = letter;
                Console.WriteLine($"{letter} - {position} - {index}");
                if (list.All(x => x != null))
                {
                    break;
                }
            } while (true);

            return string.Join("", list);
        }


        public string GetInput()
        {
            return File.ReadAllText("input1.txt");
        }
    }
}