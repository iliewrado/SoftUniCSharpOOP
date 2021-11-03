using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : IMyList
    {
        public List<string> Collection { get; set; }
        public MyList()
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
            string item = Collection[0];
            Collection.RemoveAt(0);
            return item;
        }

        public int Used()
        {
            return Collection.Count;
        }
    }
}
