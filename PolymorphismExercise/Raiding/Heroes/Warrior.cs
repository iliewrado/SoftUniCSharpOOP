namespace Raiding
{
    public class Warrior : BaseHero
    {
        private const int power = 100;

        public Warrior(string name)
        {
            Name = name;
        }
        public override string Name { get; set; }
        public override int Power 
        {
            get {return power; } 
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
