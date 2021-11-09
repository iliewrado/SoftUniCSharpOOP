using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType() == typeof(Vegetable) ||
                food.GetType() == typeof(Fruit))
            {
                Weight += food.Quantity * 0.10;
                FoodEaten += food.Quantity;
            }
            else
            {
                System.Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
        public override string ToString()
        {
            return $"{base.ToString()} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
