using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories.Contracts
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private IList<IDecoration> decorations;
        public IReadOnlyCollection<IDecoration> Models
            => (IReadOnlyCollection<IDecoration>)decorations;

        public DecorationRepository()
        {
           this.decorations = new List<IDecoration>();
        }

        public void Add(IDecoration model)
        {
            this.decorations.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            return this.decorations.FirstOrDefault(x=> x.GetType().Name == type);
        }

        public bool Remove(IDecoration model)
        {
            return decorations.Remove(model);
        }
    }
}
