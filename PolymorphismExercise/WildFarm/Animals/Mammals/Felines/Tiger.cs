using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, 
            string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
        public override string ToString()
        {
            return $"{base.ToString()} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
        public override void Eat(Food food)
        {
            if (food.GetType() == typeof(Meat))
            {
                Weight += food.Quantity * 1.00;
                FoodEaten += food.Quantity;
            }
            else
            {
                System.Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
