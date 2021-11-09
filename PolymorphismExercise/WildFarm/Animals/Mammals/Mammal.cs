namespace WildFarm.Animals.Mammals
{
    public abstract class Mammal : Animal
    {
        public string LivingRegion { get; set; }
        protected Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            LivingRegion = livingRegion;
        }
        public override string ToString()
        {
            return base.GetType().Name;
        }
    }
}
