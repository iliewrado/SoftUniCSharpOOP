using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        public List<string> Collection { get; set; }
        public AddRemoveCollection()
        {
            Collection = new List<string>();
        }

        public int Add(string item)
        {
            Collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string item = Collection[Collection.Count - 1];
            Collection.RemoveAt(Collection.Count - 1);
            return item;
        }
    }
}
