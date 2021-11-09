using WildFarm.Animals;
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
        public override string ToString()
        {
            return $"{base.ToString()} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
        public override void Eat(Food food)
        {
            if (food.GetType() == typeof(Meat))
            {
                Weight += food.Quantity * 0.25;
                FoodEaten += food.Quantity;
            }
            else
            {
                System.Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
