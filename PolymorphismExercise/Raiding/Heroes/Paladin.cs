namespace Raiding
{
    public class Paladin : BaseHero
    {
        private const int power = 100;

        public Paladin(string name) 
        {
            Name = name;
        }
        public override string Name { get; set; }
        public override int Power
        {
            get { return power; }
        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
