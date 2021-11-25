using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly IList<IAstronaut> astronauts;

        public AstronautRepository()
        {
            this.astronauts = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => 
            (IReadOnlyCollection<IAstronaut>)astronauts;

        public void Add(IAstronaut astronaut)
        {
            this.astronauts.Add(astronaut);
        }

        public IAstronaut FindByName(string name)
        {
            return this.astronauts.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IAstronaut astronaut)
        {
            return this.astronauts.Remove(astronaut);
        }
    }
}
