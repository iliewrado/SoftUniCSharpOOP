using MilitaryElite.Classes;
using System.Collections.Generic;
namespace MilitaryElite
{
    interface ILieutenantGeneral
    {
        public ICollection<Private> Privates { get; }
    }
}
