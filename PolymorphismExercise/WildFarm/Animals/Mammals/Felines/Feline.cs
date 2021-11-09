namespace WildFarm.Animals.Mammals.Felines
{
    public abstract class Feline : Mammal
    {
        public string Breed { get; set; }
        protected Feline(string name, double weight, 
            string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            Breed = breed;
        }
        public override string ToString()
        {
            return base.GetType().Name;
        }
    }
}
