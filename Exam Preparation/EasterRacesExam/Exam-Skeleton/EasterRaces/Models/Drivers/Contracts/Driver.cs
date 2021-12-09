using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Drivers.Contracts
{
    public class Driver :IDriver
    {
        private string name;
        public ICar Car { get; private set; }
        public int NumberOfWins { get; private set; }
        public bool CanParticipate { get; private set; } = false;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) 
                    || value.Length < 5)
                {
                    throw new ArgumentException
                        (string.Format(ExceptionMessages.InvalidName, value, 5));
                }
                name = value; 
            }
        }

        public Driver(string name)
        {
            Name = name;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException
                    (ExceptionMessages.CarInvalid);
            }

            this.Car = car;
            this.CanParticipate = true;
        }
    }
}
