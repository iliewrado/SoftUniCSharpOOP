using MilitaryElite.Enums;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Classes
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firsName, string lastName, decimal salary, 
            CorpEnum corp, ICollection<Repair> repairs) 
            : base(id, firsName, lastName, salary, corp)
        {
            Repairs = repairs;
        }

        public ICollection<Repair> Repairs { get ; set ; }
        public override string ToString()
        {
            StringBuilder engineer = new StringBuilder();
            engineer.AppendLine(base.ToString());
            engineer.AppendLine($"Corps: {Corp}");
            engineer.AppendLine("Repairs:");
            foreach (var item in Repairs)
            {
                engineer.AppendLine(item.ToString());
            }
            return engineer.ToString().TrimEnd();
        }
    }
}
