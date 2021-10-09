using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;
        private List<Product> products;

        public List<Product> Products
        {
            get { return products; }
            private set { products = value; }
        }

        public double Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
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
        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            Products = new List<Product>();
        }
        public void AddProduct(Product product)
        {
            if (money < product.Cost)
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
            else
            {
                products.Add(product);
                Console.WriteLine($"{Name} bought {product.Name}");
                money -= product.Cost;
            }
        }
        public override string ToString()
        {
            return $"{Name} - {(products.Count > 0 ? string.Join(", ", products) : "Nothing bought")}";
        }
    }
}
