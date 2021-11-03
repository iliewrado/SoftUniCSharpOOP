using MilitaryElite.Classes;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firsName, string lastName, decimal salary, 
            ICollection<Private> privates)
            : base(id, firsName, lastName, salary)
        {
            Privates = privates;
        }
        public ICollection<Private> Privates { get; set; }
        public override string ToString()
        {
            StringBuilder Lieutenant = new StringBuilder();
            Lieutenant.AppendLine(base.ToString());
            Lieutenant.AppendLine("Privates:");
            foreach (var item in Privates)
            {
                Lieutenant.AppendLine($"  {item.ToString()}");
            }
            return Lieutenant.ToString().TrimEnd();
        }
    }
}
