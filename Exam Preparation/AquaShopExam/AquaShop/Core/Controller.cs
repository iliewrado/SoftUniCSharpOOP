using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        public DecorationRepository decorations { get; }
        public List<IAquarium> aquariums { get; }

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            switch (aquariumType)
            {
                case "FreshwaterAquarium":
                    aquariums.Add(new FreshwaterAquarium(aquariumName));
                    return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
                case "SaltwaterAquarium":
                    aquariums.Add(new SaltwaterAquarium(aquariumName));
                    return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
                default:
                    throw new InvalidOperationException
                        (ExceptionMessages.InvalidAquariumType);
            }
        }

        public string AddDecoration(string decorationType)
        {
            switch (decorationType)
            {
                case "Ornament":
                    decorations.Add(new Ornament());
                    return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
                case "Plant":
                    decorations.Add(new Plant());
                    return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
                default:
                    throw new InvalidOperationException
                        (ExceptionMessages.InvalidDecorationType);
            }
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = decorations.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            int index = aquariums.FindIndex(x => x.Name == aquariumName);
            aquariums[index].AddDecoration(decoration);
            decorations.Remove(decoration);
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;
            switch (fishType)
            {
                case "FreshwaterFish":
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                    break;
                case "SaltwaterFish":
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                    break;
                default:
                    throw new InvalidOperationException
                        (ExceptionMessages.InvalidFishType);
            }
            int index = aquariums.FindIndex(x => x.Name == aquariumName);
            if (aquariums[index].GetType().Name == "FreshwaterAquarium"
                && fish.GetType().Name == "FreshwaterFish")
            {
                aquariums[index].AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);

            }
            else if (aquariums[index].GetType().Name == "SaltwaterAquarium"
                && fish.GetType().Name == "SaltwaterFish")
            {
                aquariums[index].AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else
            {
                return OutputMessages.UnsuitableWater;
            }
        }

        public string FeedFish(string aquariumName)
        {
            int index = aquariums.FindIndex(x => x.Name == aquariumName);
            aquariums[index].Feed();
            return string.Format(OutputMessages.FishFed, aquariums[index].Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            int index = aquariums.FindIndex(x => x.Name == aquariumName);
            decimal decorPrice = aquariums[index].Comfort;
            decimal fishPrice = 0;
            foreach (var fish in aquariums[index].Fish)
            {
                fishPrice += fish.Price;
            }
            decimal total = decorPrice + fishPrice;
            return string.Format(OutputMessages.AquariumValue, aquariumName, total);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                report.AppendLine(aquarium.GetInfo());
            }
            return report.ToString().TrimEnd();
        }
    }
}
