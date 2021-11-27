using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        public ICollection<IDye> Dyes { get; }

        public int Energy
        {
            get { return energy; }
            protected set 
            {
                if (value < 0)
                {
                    energy = 0;
                }
                energy = value; 
            }
        }


        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidBunnyName);
                }
                name = value;
            }
        }

        protected Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            Dyes = new List<IDye>();
        }

        public virtual void Work()
        {
            this.Energy -= 10;
        }

        public void AddDye(IDye Dye)
        {
            Dyes.Add(Dye);
        }
    }
}
