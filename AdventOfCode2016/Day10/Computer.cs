using System.Collections.Generic;
using System.Linq;

namespace Day10
{
    public class Computer
    {
        private readonly List<Bot> _bots = new List<Bot>();

        private readonly List<Output> _outputs = new List<Output>();

        public List<Instruction> Instructions { get; set; } = new List<Instruction>();

        public Bot GetBot(int botId)
        {
            var bot = _bots.FirstOrDefault(x => x.Id == botId);
            if (bot == null)
            {
                bot = new Bot(botId);
                _bots.Add(bot);
            }
            return bot;
        }

        public Output GetOutput(int outputId)
        {
            var output = _outputs.FirstOrDefault(x => x.Id == outputId);
            if (output == null)
            {
                output = new Output(outputId);
                _outputs.Add(output);
            }
            return output;
        }

        public Bot GetNextReadyBot()
        {
            return _bots.FirstOrDefault(x => x.Ready);
        }

        public bool CheckStopConditionForBot(Bot bot)
        {
            if (bot == null)
            {
                return false;
            }
            return bot.Chips.Contains(61) && bot.Chips.Contains(17);
        }
    }
}