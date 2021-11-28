using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;
using System;

namespace SpaceStation.Models.Astronauts
{
    public class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;

        public double Oxygen
        {
            get { return oxygen; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidOxygen);
                }
                oxygen = value; 
            }
        }
        
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException
                        (ExceptionMessages.InvalidAstronautName);
                }
                name = value; 
            }
        }

        public IBag Bag { get; }

        public bool CanBreath => this.Oxygen > 0;

        protected Astronaut(string name, double oxygen)
        {
            this.name = name;
            this.oxygen = oxygen;
            Bag = new Backpack();
        }

        public virtual void Breath()
        {
            if (this.Oxygen - 10 < 0)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen -= 10;
            }
        }
    }
}
