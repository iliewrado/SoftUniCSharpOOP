using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class Program
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            List<int> adds = new List<int>();
            List<int> removeAdds = new List<int>();
            List<int> myAdds = new List<int>();

            string[] elements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int removeOperations = int.Parse(Console.ReadLine());

            foreach (var element in elements)
            {
                adds.Add(addCollection.Add(element));
                removeAdds.Add(addRemoveCollection.Add(element));
                myAdds.Add(myList.Add(element));
            }
            List<string> removed = new List<string>();
            List<string> myRemoved = new List<string>();

            for (int i = 0; i < removeOperations; i++)
            {
                removed.Add(addRemoveCollection.Remove());
                myRemoved.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(' ', adds));
            Console.WriteLine(string.Join(' ', removeAdds));
            Console.WriteLine(string.Join(' ', myAdds));
            Console.WriteLine(string.Join(' ', removed));
            Console.WriteLine(string.Join(' ', myRemoved));
        }
    }
}
