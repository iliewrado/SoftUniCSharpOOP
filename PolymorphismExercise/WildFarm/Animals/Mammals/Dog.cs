using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
        public override string ToString()
        {
            return $"{base.ToString()} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
        public override void Eat(Food food)
        {
            if (food.GetType() == typeof(Meat))
            {
                Weight += food.Quantity * 0.40;
                FoodEaten += food.Quantity;
            }
            else
            {
                System.Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
