using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            return GetAll().FirstOrDefault(x => x.Name == name);
        }
    }
}
