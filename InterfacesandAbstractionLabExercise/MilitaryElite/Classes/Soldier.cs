namespace MilitaryElite
{
    public abstract class Soldier : ISoldier
    {
        public int Id { get; set; }
        public string FirstNsame { get; set; }
        public string LastName { get; set; }
        public Soldier(int id, string firsName, string lastName)
        {
            Id = id;
            FirstNsame = firsName;
            LastName = lastName;
        }
        public override string ToString()
        {
            return $"Name: {FirstNsame} {LastName} Id: {Id}";
        }
    }
}
