using System;
using System.Collections.Generic;
using System.Text;

namespace _04PizzaCalories
{
    public class Topping
    {

        private string type;
        private double weight;
        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }
        public double Weight
        {
            get { return weight; }
            set 
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }
                weight = value; 
            }
        }

        public string Type
        {
            get { return type; }
            private set
            {
                switch (value.ToUpper())
                {
                    case "MEAT":
                    case "VEGGIES":
                    case "CHEESE":
                    case "SAUCE":
                        type = value;
                        break;
                    default:
                        throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
        }

        public double CaloriesPerGram()
        {
            double baseCalories = 2;
            double modifier = 0;
            switch (Type.ToUpper())
            {
                case "MEAT":
                    modifier = 1.2;
                    break;
                case "VEGGIES":
                    modifier = 0.8;
                    break;
                case "CHEESE":
                    modifier = 1.1;
                    break;
                case "SAUCE":
                    modifier = 0.9;
                    break;
            }
            return baseCalories * modifier * Weight;
        }
    }
}
