using WildFarm.Foods;

namespace WildFarm.Animals
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
        public abstract string ProduceSound();
        public abstract void Eat(Food food);
    }
}
