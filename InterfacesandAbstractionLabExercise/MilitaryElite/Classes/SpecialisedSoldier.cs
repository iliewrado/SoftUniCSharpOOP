using MilitaryElite.Enums;
namespace MilitaryElite.Classes
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firsName, string lastName, decimal salary,
            CorpEnum corp)
            : base(id, firsName, lastName, salary)
        {
            Corp = corp;
        }

        public CorpEnum Corp { get ; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
