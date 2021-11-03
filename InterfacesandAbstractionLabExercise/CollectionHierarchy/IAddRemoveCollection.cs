using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    interface IAddRemoveCollection : IAddCollection
    {
        string Remove();
    }
}
