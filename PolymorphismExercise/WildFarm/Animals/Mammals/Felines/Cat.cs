using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight,
            string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
        public override string ToString()
        {
            return $"{base.ToString()} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
        public override void Eat(Food food)
        {
            if (food.GetType() == typeof(Vegetable) ||
                food.GetType() == typeof(Meat))
            {
                Weight += food.Quantity * 0.30;
                FoodEaten += food.Quantity;
            }
            else
            {
                System.Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
