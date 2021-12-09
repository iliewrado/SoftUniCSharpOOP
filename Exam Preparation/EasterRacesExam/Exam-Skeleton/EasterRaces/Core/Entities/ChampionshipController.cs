using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository drivers;
        private CarRepository cars;
        private RaceRepository races;

        public ChampionshipController()
        {
            drivers = new DriverRepository();
            cars = new CarRepository();
            races = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = drivers.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages
                    .DriverNotFound, driverName));
            }

            ICar car = cars.GetByName(carModel);

            if (car == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages
                    .CarNotFound, carModel));
            }

            driver.AddCar(car);
            return string.Format(OutputMessages
                .CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages
                    .RaceNotFound, raceName));
            }
            IDriver driver = drivers.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages
                    .DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return string.Format(OutputMessages
                .DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = cars.GetByName(model);
            if (car != null)
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.CarExists, model));
            }

            switch (type)
            {
                case "Muscle":
                    car = new MuscleCar(model, horsePower);
                    break;
                case "Sports":
                    car = new SportsCar(model, horsePower);
                    break;
            }

            cars.Add(car);

            return string.Format(OutputMessages
                .CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = drivers.GetByName(driverName);
            
            if (driver != null)
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages
                    .DriversExists, driverName));
            }

            driver = new Driver(driverName);
            drivers.Add(driver);
            return string.Format(OutputMessages
                .DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = races.GetByName(name);
            if (race != null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages
                    .RaceExists, name));
            }

            race = new Race(name, laps);
            races.Add(race);

            return string.Format(OutputMessages
                .RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages
                    .RaceNotFound, raceName));
            }
            List<IDriver> participants = drivers.GetAll()
                .Where(x => x.CanParticipate)
                .OrderByDescending(x => x.Car
                .CalculateRacePoints(race.Laps))
                .ToList();
            if (participants.Count < 3)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages
                    .RaceInvalid, raceName, 3));
            }
            
            races.Remove(race);

            StringBuilder racersInfo = new StringBuilder();
            racersInfo.AppendLine(string.Format(OutputMessages
                .DriverFirstPosition, participants[0].Name, raceName));
            racersInfo.AppendLine(string.Format(OutputMessages
                .DriverSecondPosition, participants[1].Name, raceName));
            racersInfo.AppendLine(string.Format(OutputMessages
                .DriverThirdPosition, participants[2].Name, raceName));
            return racersInfo.ToString().TrimEnd();
        }
    }
}
