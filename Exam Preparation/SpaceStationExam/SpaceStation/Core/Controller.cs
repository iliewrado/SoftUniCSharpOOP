using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private int exploredPlanetsCount = 0;
        public IRepository<IAstronaut> astronautRepository { get; private set; }
        public IRepository<IPlanet> planetRepository { get; private set; }

        public Controller()
        {
            astronautRepository = new AstronautRepository();
            planetRepository = new PlanetRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            switch (type)
            {
                case "Biologist":
                    astronaut = new Biologist(astronautName);
                    break;
                case "Geodesist":
                    astronaut = new Geodesist(astronautName);
                    break;
                case "Meteorologist":
                    astronaut = new Meteorologist(astronautName);
                    break;
                default:
                    throw new InvalidOperationException
                        (ExceptionMessages.InvalidAstronautType);
            }
            astronautRepository.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            planetRepository.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            IMission mission = new Mission();
            IPlanet planet = planetRepository.FindByName(planetName);
            ICollection<IAstronaut> astronauts = astronautRepository
                .Models.Where(x => x.Oxygen > 60).ToList();
            if (astronauts.Count <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            mission.Explore(planet, astronauts);
            exploredPlanetsCount++;
            int deadAstronauts = 0;
            foreach (var astro in astronauts)
            {
                if (!astro.CanBreath)
                {
                    deadAstronauts++;
                }
            }
            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"{exploredPlanetsCount} planets were explored!");
            report.AppendLine("Astronauts info:");
            foreach (var astronaut in astronautRepository.Models)
            {
                report.AppendLine($"Name: {astronaut.Name}");
                report.AppendLine($"Oxygen: {astronaut.Oxygen}");
                string bagitems = astronaut.Bag.Items.Any() ? string.Join(", ", astronaut.Bag.Items) : "none";
                report.AppendLine($"Bag items: {bagitems}");
            }

            return report.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronautRepository.FindByName(astronautName);
            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            astronautRepository.Remove(astronaut);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
