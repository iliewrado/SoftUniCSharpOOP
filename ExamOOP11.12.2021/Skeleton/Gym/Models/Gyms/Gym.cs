using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public class Gym : IGym
    {
        private string name;
        private int capacity;
        private readonly List<IEquipment> equipments;
        private readonly List<IAthlete> athletes;
        public double EquipmentWeight 
            => equipments.Sum(x => x.Weight);

        public int Capacity
        {
            get { return capacity; }
            private set
            { 
                
                capacity = value; 
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
                        (ExceptionMessages.InvalidGymName);
                }
                name = value;
            }
        }

        public ICollection<IAthlete> Athletes => athletes;
        public ICollection<IEquipment> Equipment => equipments;

        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            athletes = new List<IAthlete>();
            equipments = new List<IEquipment>();
        }

        public void AddAthlete(IAthlete athlete)
        {
            if (athletes.Count == Capacity)
            {
                throw new InvalidOperationException
                    (ExceptionMessages.NotEnoughSize);
            }
            athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            equipments.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder gimInfo = new StringBuilder();
            gimInfo.AppendLine($"{Name} is a {this.GetType().Name}:");
            List<string> athleteNames = new List<string>();
            foreach (var item in athletes)
            {
                athleteNames.Add(item.FullName);
            }
            string names = athleteNames.Count > 0 ? string.Join(", ", athleteNames) : "No athletes";
            gimInfo.AppendLine($"Athletes: {names}");
            gimInfo.AppendLine($"Equipment total count: {equipments.Count}");
            gimInfo.AppendLine($"Equipment total weight: {EquipmentWeight:F2} grams");
            return gimInfo.ToString().TrimEnd();
        }
    }
}
