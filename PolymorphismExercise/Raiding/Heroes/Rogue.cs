namespace Raiding
{
    public class Rogue : BaseHero
    {
        private const int power = 80;

        public Rogue(string name)
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
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
