using System;
using System.Collections.Generic;
using System.Linq;

namespace Day10
{
    public class Bot : ChipContainer
    {
        private const int ChipsMaxCount = 2;

        public Bot(int id) : base(id)
        {
        }

        public override void AddChip(int chip)
        {
            if (Chips.Count == ChipsMaxCount)
            {
                throw new InvalidOperationException("Нельзя добавить боту третий чип");
            }
            base.AddChip(chip);
        }

        public void ApplyInstruction(Instruction instruction)
        {
            if (instruction == null)
            {
                throw new ArgumentNullException(nameof(instruction));
            }
            if (instruction.Bot!=this)
            {
                throw new InvalidOperationException($"Чужая инструкция");
            }
            if (!Ready)
            {
                throw new InvalidOperationException($"Bot {Id} еще не готов");
            }
            var orderedChips = Chips.OrderBy(x => x).ToArray();
            
            instruction.LowDestination.AddChip(orderedChips[0]);
            instruction.HighDestination.AddChip(orderedChips[1]);
            Chips.Clear();
        }
        

        public bool Ready => Chips.Count == ChipsMaxCount;
    }
}