using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private IRepository<IEquipment> EquipmentRepository;
        private List<IGym> Gyms;

        public Controller()
        {
            EquipmentRepository = new EquipmentRepository();
            Gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete = null;
            switch (athleteType)
            {
                case "Boxer":
                    athlete = new Boxer(athleteName, motivation, numberOfMedals);
                    break;
                case "Weightlifter":
                    athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                    break;
                default:
                    throw new InvalidOperationException
                        (ExceptionMessages.InvalidAthleteType);
            }
            IGym gym = Gyms.FirstOrDefault(x => x.Name == gymName);
            if (gym.GetType().Name == "BoxingGym"
                && athlete.GetType().Name == "Boxer")
            {
                gym.AddAthlete(athlete);
                return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }
            else if (gym.GetType().Name == "WeightliftingGym"
                && athlete.GetType().Name == "Weightlifter")
            {
                gym.AddAthlete(athlete);
                return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }
            else
            {
                return OutputMessages.InappropriateGym;
            }
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment = null;
            switch (equipmentType)
            {
                case "BoxingGloves":
                    equipment = new BoxingGloves();
                    break;
                case "Kettlebell":
                    equipment = new Kettlebell();
                    break;
                default:
                    throw new InvalidOperationException
                        (ExceptionMessages.InvalidEquipmentType);
            }
            EquipmentRepository.Add(equipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = null;
            switch (gymType)
            {
                case "BoxingGym":
                    gym = new BoxingGym(gymName);
                    break;
                case "WeightliftingGym":
                    gym = new WeightliftingGym(gymName);
                    break;
                default:
                    throw new InvalidOperationException
                        (ExceptionMessages.InvalidGymType);
            }
            Gyms.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = Gyms.FirstOrDefault(x => x.Name == gymName);
            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = EquipmentRepository.FindByType(equipmentType);
            if (equipment == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            IGym gym = Gyms.FirstOrDefault(x => x.Name == gymName);
            gym.AddEquipment(equipment);
            EquipmentRepository.Remove(equipment);
            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            foreach (var gym in Gyms)
            {
                report.AppendLine(gym.GymInfo());
            }
            return report.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = Gyms.FirstOrDefault(x => x.Name == gymName);
            gym.Exercise();
            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}
