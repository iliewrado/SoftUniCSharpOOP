namespace MilitaryElite.Classes
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firsName, string lastName, decimal salary)
            : base(id, firsName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()} Salary: {Salary:f2}";
        }
    }
}
