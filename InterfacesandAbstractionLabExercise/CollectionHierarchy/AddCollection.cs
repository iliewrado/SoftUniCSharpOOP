using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        public List<string> Collection { get; private set; }
        public AddCollection()
        {
            Collection = new List<string>();
        }

        public int Add(string item)
        {
            Collection.Add(item);
            return Collection.Count - 1;
        }
    }
}
