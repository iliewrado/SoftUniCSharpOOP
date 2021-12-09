using System.Collections.Generic;

namespace EasterRaces.Repositories.Contracts
{
    public abstract class Repository<T> : IRepository<T>
    {
        private readonly List<T> Models;

        protected Repository()
        {
            Models = new List<T>();
        }

        public void Add(T model)
        {
            Models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return Models as IReadOnlyCollection<T>;
        }

        public abstract T GetByName(string name);
        
        public bool Remove(T model)
        {
            return Models.Remove(model);
        }
    }
}
