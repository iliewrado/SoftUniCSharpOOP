using MilitaryElite.Enums;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Classes
{
    public class Commando : SpecialisedSoldier, IComando
    {
        public Commando(int id, string firsName, string lastName, decimal salary,
            CorpEnum corp, ICollection<Mission> missions) 
            : base(id, firsName, lastName, salary, corp)
        {
            Missions = missions;
        }

        public ICollection<Mission> Missions { get; set; }
        public override string ToString()
        {
            StringBuilder commando = new StringBuilder();
            commando.AppendLine(base.ToString());
            commando.AppendLine($"Corps: {Corp}");
            commando.AppendLine("Missions:");
            foreach (var item in Missions)
            {
                commando.AppendLine($"  {item.ToString()}");
            }
            return commando.ToString().TrimEnd();
        }
    }
}
