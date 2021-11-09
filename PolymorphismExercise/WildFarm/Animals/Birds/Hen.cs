using WildFarm.Animals;
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
        public override string ToString()
        {
            return $"{base.ToString()} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
        public override void Eat(Food food)
        {
            Weight += food.Quantity * 0.35;
            FoodEaten += food.Quantity;
        }
    }
}
