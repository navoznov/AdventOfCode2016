using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Common;

namespace Day10
{
    internal class Part2 : IPart<int>
    {
        public int Solve()
        {
            var input = File.ReadAllLines("input1.txt");
            var valueRegex = new Regex(@"value (\d+) goes to bot (\d+)");
            var computer = new Computer();
            Bot bot;
            // parse model
            foreach (var line in input)
            {
                var match = valueRegex.Match(line);
                if (match.Success)
                {
                    var chipValue = int.Parse(match.Groups[1].Value);
                    var botId = int.Parse(match.Groups[2].Value);
                    bot = computer.GetBot(botId);
                    bot.AddChip(chipValue);
                }
                else
                {
                    var instruction = ParseInstruction(line, computer);
                    computer.Instructions.Add(instruction);
                }
            }

            // apply instruction to ready bots
            while ((bot = computer.GetNextReadyBot()) != null)
            {
                var instruction = computer.Instructions.FirstOrDefault(x => x.Bot == bot);
                if (instruction != null)
                {
                    bot.ApplyInstruction(instruction);
                }
            }

            var outputIds = new[] { 0, 1, 2 };
            return outputIds.Aggregate(1, (seed, x) => seed*computer.GetOutput(x).Chips.First());
        }

        private static Instruction ParseInstruction(string line, Computer computer)
        {
            var instructionRegex = new Regex(@"bot (\d+) gives low to (\w+) (\d+) and high to (\w+) (\d+)");
            var match = instructionRegex.Match(line);

            var bot = computer.GetBot(int.Parse(match.Groups[1].Value));
            var lowChipContainer = GetChipContainer(computer, match.Groups[2].Value, int.Parse(match.Groups[3].Value));
            var highChipContainer = GetChipContainer(computer, match.Groups[4].Value, int.Parse(match.Groups[5].Value));

            return new Instruction(bot, lowChipContainer, highChipContainer);
        }

        private static ChipContainer GetChipContainer(Computer computer, string type, int destId)
        {
            if (type == "bot")
            {
                return computer.GetBot(destId);
            }
            return computer.GetOutput(destId);
        }
    }
}