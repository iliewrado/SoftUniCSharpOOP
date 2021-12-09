using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace EasterRaces.Models.Races.Contracts
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private IList<IDriver> drivers;

        public int Laps
        {
            get { return laps; }
            private set 
            {
                if (value < 1)
                {
                    throw new ArgumentException
                        (string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }
                laps = value;
            }
        }

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

        public IReadOnlyCollection<IDriver> Drivers =>
            (IReadOnlyCollection<IDriver>)drivers;

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            drivers = new List<IDriver>();
        }

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException
                    (ExceptionMessages.DriverInvalid);
            }
            if (driver.CanParticipate == false)
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages
                    .DriverNotParticipate, driver.Name));
            }
            if (drivers.Contains(driver))
            {
                throw new ArgumentNullException
                    (string.Format(ExceptionMessages
                    .DriverAlreadyAdded, driver.Name, this.Name));
            }

            drivers.Add(driver);
        }
    }
}
