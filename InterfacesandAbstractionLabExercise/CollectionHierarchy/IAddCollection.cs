using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    interface IAddCollection
    {
        List<string> Collection { get; }
        int Add(string item);
    }
}
