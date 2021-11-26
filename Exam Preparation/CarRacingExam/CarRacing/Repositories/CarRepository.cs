using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private IList<ICar> cars;
        public IReadOnlyCollection<ICar> Models { get; }

        public CarRepository()
        {
            cars = new List<ICar>();
            Models = (IReadOnlyCollection<ICar>)cars;
        }

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException
                    (ExceptionMessages.InvalidAddCarRepository);
            }
            cars.Add(model);
        }

        public bool Remove(ICar model)
        {
            return cars.Remove(model);
        }

        public ICar FindBy(string property)
        {
            return cars.FirstOrDefault(x => x.VIN == property);
        }
    }
}
