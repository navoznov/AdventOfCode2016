using System.Collections.Generic;

namespace Day10
{
    public abstract class ChipContainer
    {
        public readonly List<int> Chips = new List<int>();

        public int Id { get; protected set; }

        protected ChipContainer(int id)
        {
            Id = id;
        }

        public virtual void AddChip(int chip)
        {
            Chips.Add(chip);
        }
    }
}