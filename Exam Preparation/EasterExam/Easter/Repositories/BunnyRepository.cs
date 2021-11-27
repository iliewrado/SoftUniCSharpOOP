﻿using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private IList<IBunny> bunnies;
        public IReadOnlyCollection<IBunny> Models
            => (IReadOnlyCollection<IBunny>)bunnies;

        public BunnyRepository()
        {
            bunnies = new List<IBunny>();
        }

        public void Add(IBunny model)
        {
            bunnies.Add(model);
        }

        public IBunny FindByName(string name)
        {
            return bunnies.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IBunny model)
        {
            return bunnies.Remove(model);
        }
    }
}
