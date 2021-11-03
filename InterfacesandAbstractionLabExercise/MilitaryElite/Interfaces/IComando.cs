using MilitaryElite.Classes;
using System.Collections.Generic;
namespace MilitaryElite
{
    interface IComando
    {
        public ICollection<Mission> Missions { get; }
    }
}
