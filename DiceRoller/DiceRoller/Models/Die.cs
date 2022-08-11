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

        public Die()
        {
            NumSides = 6;
            Name = "d6";
            Roll();
        }

        public Die(int numSides)
        {
            NumSides = numSides;
            Name = "d" + numSides;
            Roll();
        }

        public Die(int numSides, String name)
        {
            NumSides = numSides;
            Name = name;
            Roll();
        }

        public void SetSideUp(int newSideUp)
        {
            if(newSideUp >= 1 && newSideUp <= NumSides)
                this.CurrentSide = newSideUp;
        }

        public void Roll()
        {
            Random r = new Random();
            CurrentSide = r.Next(NumSides) + 1;
        }
    }

    
}

