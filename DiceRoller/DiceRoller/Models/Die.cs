using System;
namespace DiceRoller
{
    public class Die
    {
        // name, type, or color of the die
        public String Name { get; set; }

        // Number of sides
        public int NumSides { get; set; }

        // which number is curren
        public int CurrentSide { get; set; }
    }
}

