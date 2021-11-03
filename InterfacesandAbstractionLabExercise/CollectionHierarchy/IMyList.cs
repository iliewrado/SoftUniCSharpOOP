using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    interface IMyList : IAddRemoveCollection
    {
        int Used();
    }
}
