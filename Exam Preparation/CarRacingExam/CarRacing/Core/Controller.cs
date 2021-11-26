using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private IRepository<ICar> carRepositorie;
        private IRepository<IRacer> racerRepositorie;
        private IMap map;

        public Controller()
        {
            carRepositorie = new CarRepository();
            racerRepositorie = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            switch (type)
            {
                case "SuperCar":
                    ICar car = new SuperCar(make, model, VIN, horsePower);
                    carRepositorie.Add(car);
                    return string.Format(OutputMessages
                        .SuccessfullyAddedCar, make, model, VIN);
                case "TunedCar":
                    car = new TunedCar(make, model, VIN, horsePower);
                    carRepositorie.Add(car);
                    return string.Format(OutputMessages
                        .SuccessfullyAddedCar, make, model, VIN);
                default:
                    throw new ArgumentException
                        (ExceptionMessages.InvalidCarType);
            }
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = carRepositorie.FindBy(carVIN);
            if (car == null)
            {
                throw new AggregateException
                    (ExceptionMessages.CarCannotBeFound);
            }
            switch (type)
            {
                case "ProfessionalRacer":
                    IRacer racer = new ProfessionalRacer(username, car);
                    racerRepositorie.Add(racer);
                    return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
                case "StreetRacer":
                    racer = new StreetRacer(username, car);
                    racerRepositorie.Add(racer);
                    return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
                default:
                    throw new ArgumentException
                        (ExceptionMessages.InvalidRacerType);
            }
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racerRepositorie.FindBy(racerOneUsername);
            IRacer racerTwo = racerRepositorie.FindBy(racerTwoUsername);
            
            if (racerOne == null)
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            else if (racerTwo == null)
            {
                throw new ArgumentException
                   (string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            foreach (var racer in racerRepositorie.Models
                .OrderByDescending(x => x.DrivingExperience)
                .ThenBy(x => x.Username))
            {
                report.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                report.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                report.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                report.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
            }

            return report.ToString().TrimEnd();
        }
    }
}
