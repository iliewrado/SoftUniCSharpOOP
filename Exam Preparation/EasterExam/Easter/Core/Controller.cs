using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Eggs;
using Easter.Models.Workshops;

namespace Easter.Core
{
    public class Controller : IController
    {
        private IRepository<IBunny> bunnyRepository;
        private IRepository<IEgg> eggRepository;
        private Workshop workshop;
        private int eggDoneCount;

        public Controller()
        {
            bunnyRepository = new BunnyRepository();
            eggRepository = new EggRepository();
            workshop = new Workshop();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            switch (bunnyType)
            {
                case "HappyBunny":
                    IBunny bunny = new HappyBunny(bunnyName);
                    bunnyRepository.Add(bunny);
                    return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
                case "SleepyBunny":
                    bunny = new SleepyBunny(bunnyName);
                    bunnyRepository.Add(bunny);
                    return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
                default:
                    throw new InvalidOperationException
                        (ExceptionMessages.InvalidBunnyType);
            }
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IDye dye = new Dye(power);
            IBunny bunny = bunnyRepository.FindByName(bunnyName);
            if (bunny == null)
            {
                throw new InvalidOperationException
                    (ExceptionMessages.InexistentBunny);
            }
            bunny.AddDye(dye);
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggRepository.Add(egg);
            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            List<IBunny> bunnies = bunnyRepository.Models.Where(x => x.Energy >= 50).ToList();
            if (bunnies.Count == 0)
            {
                throw new InvalidOperationException
                    (ExceptionMessages.BunniesNotReady);
            }

            IEgg egg = eggRepository.FindByName(eggName);
            while(!egg.IsDone() && bunnies.Count > 0)
            {
                IBunny bunny = bunnies.First();
                workshop.Color(egg, bunny);
                if (bunny.Energy == 0)
                {
                    bunnyRepository.Remove(bunny);
                    bunnies.Remove(bunny);
                }
                if (bunny.Dyes.Count == 0)
                {
                    break;
                }
            }

            if (egg.IsDone())
            {
                eggDoneCount++;
                return string.Format(OutputMessages.EggIsDone, eggName);
            }

            return string.Format(OutputMessages.EggIsDone, eggName);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"{eggDoneCount} eggs are done!");
            report.AppendLine("Bunnies info:");
            foreach (var bunny in bunnyRepository.Models)
            {
                report.AppendLine($"Name: {bunny.Name}");
                report.AppendLine($"Energy: {bunny.Energy}");
                List<IDye> dyesCount = bunny.Dyes.Where(x => x.Power > 0).ToList();
                report.AppendLine($"Dyes: {dyesCount.Count} not finished");
            }

            return report.ToString().TrimEnd();
        }
    }
}
