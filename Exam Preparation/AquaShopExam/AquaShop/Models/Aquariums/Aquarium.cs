using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium  : IAquarium
    {
        private string name;
        private IList<IDecoration> decorations;
        private IList<IFish> fish;

        public int Comfort => decorations.Sum(x => x.Comfort);
        public int Capacity {get;}
        public ICollection<IDecoration> Decorations
            => (ICollection<IDecoration>)decorations;
        public ICollection<IFish> Fish
            => (ICollection<IFish>)fish;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidAquariumName);
                }
                name = value; 
            }
        }

        protected Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            decorations = new List<IDecoration>();
            fish = new List<IFish>();
        }

        public void AddFish(IFish fish)
        {
            if (this.fish.Count == Capacity)
            {
                throw new InvalidOperationException
                    (ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish);
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (var fishy in this.fish)
            {
                fishy.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder aquariumInfo = new StringBuilder();
            
            aquariumInfo.AppendLine($"{this.Name} ({this.GetType().Name})");
            List<string> fishNames = new List<string>();
            foreach (var item in this.fish)
            {
                fishNames.Add(item.Name);
            }
            string names = this.fish.Count > 0 ? string.Join(", ", fishNames) : " none";
            aquariumInfo.AppendLine($"Fish: {names}");
            aquariumInfo.AppendLine($"Decorations: {decorations.Count}");
            aquariumInfo.AppendLine($"Comfort: {Comfort}");

            return aquariumInfo.ToString().TrimEnd();
        }
    }
}
