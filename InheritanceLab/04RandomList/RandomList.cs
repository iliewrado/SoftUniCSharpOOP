using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString(List<string> items)
        {
            Random rnd = new Random();
            int index = rnd.Next(0, items.Count);
            string item = items[index];
            items.Remove(item);
            return item;
        }
    }
}
