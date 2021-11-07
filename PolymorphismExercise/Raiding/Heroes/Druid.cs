namespace Raiding
{
    public class Druid : BaseHero
    {
        private const int power = 80;
        public Druid(string name)
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
