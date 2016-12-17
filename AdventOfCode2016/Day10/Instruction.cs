namespace Day10
{
    public class Instruction
    {
        public Bot Bot { get; private set; }

        public ChipContainer LowDestination { get; set; }

        public ChipContainer HighDestination { get; set; }

        public Instruction(Bot bot, ChipContainer lowDestination, ChipContainer highDestination)
        {
            Bot = bot;
            LowDestination = lowDestination;
            HighDestination = highDestination;
        }
    }
}