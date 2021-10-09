using System;
using System.Collections.Generic;
using System.Text;

namespace _03ShoppingSpree
{
    public class Product
    {
        private string name;
        private double cost;

        public double Cost
        {
            get { return cost; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                cost = value; 
            }
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value; 
            }
        }
        public Product(string name, double price)
        {
            Name = name;
            Cost = price;
        }
        public override string ToString() => Name;
    }
}
