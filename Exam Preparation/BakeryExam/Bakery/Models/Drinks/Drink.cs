using Bakery.Models.Drinks.Contracts;
using Bakery.Utilities.Messages;
using System;

namespace Bakery.Models.Drinks
{
    public class Drink : IDrink
    {
        private string name;
        private int portion;
        private decimal price;
        private string brand;

        public string Brand
        {
            get { return brand; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidBrand);
                }
                brand = value;
            }
        }

        public decimal Price
        {
            get { return price; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidPrice);
                }
                price = value; 
            }
        }

        public int Portion
        {
            get { return portion; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidPortion);
                }
                portion = value; 
            }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidName);
                }
                name = value; 
            }
        }

        public Drink(string name, int portion, decimal price, string brand)
        {
            Name = name;
            Portion = portion;
            Price = price;
            Brand = brand;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Brand} - {this.Portion}ml - {this.Price:f2}lv";
        }
    }
}
