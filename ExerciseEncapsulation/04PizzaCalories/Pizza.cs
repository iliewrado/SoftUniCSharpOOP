using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04PizzaCalories
{
    public class Pizza
    {
        private string name;
        private readonly Dough dough;
        private readonly List<Topping> topping;
        public Pizza(string name, Dough dough)
        {
            Name = name;
            this.dough = dough;
            this.topping = new List<Topping>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) && value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public double TotalCalories()
        {
            return this.topping.Sum(x => x.CaloriesPerGram()) + dough.CaloriesCalculator();
        }
        public void AddTopping(Topping topping)
        {
            this.topping.Add(topping);
            if (this.topping.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }
        public override string ToString()
        {
            return $"{Name} - {this.TotalCalories():f2} Calories.";
        }
    }
}
