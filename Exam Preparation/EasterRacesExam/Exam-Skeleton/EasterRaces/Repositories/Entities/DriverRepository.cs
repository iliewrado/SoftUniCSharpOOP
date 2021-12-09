using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : Repository<IDriver>
    {
        public override IDriver GetByName(string name)
        {
            return GetAll().FirstOrDefault(x => x.Name == name);
        }
    }

}
