using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public class Table : ITable
    {
        private readonly List<IBakedFood> FoodOrders;
        private readonly List<IDrink> DrinkOrders;
        private int capacity;
        private int numberOfPeople;

        public decimal PricePerPerson { get; }
        public bool IsReserved { get; private set; }
        public decimal Price =>
            PricePerPerson * NumberOfPeople
            + DrinkOrders.Sum(x => x.Price)
                + FoodOrders.Sum(x => x.Price);
        public int NumberOfPeople
        {
            get { return numberOfPeople; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidNumberOfPeople);
                }
                numberOfPeople = value;
            }
        }

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidTableCapacity);
                }
                capacity = value;
            }
        }

        public int TableNumber { get; }

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.IsReserved = false;
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
            FoodOrders = new List<IBakedFood>();
            DrinkOrders = new List<IDrink>();
        }

        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }

        public void OrderFood(IBakedFood food)
        {
            FoodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            DrinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            return Price;
        }

        public void Clear()
        {
            this.IsReserved = false;
            this.FoodOrders.Clear();
            this.DrinkOrders.Clear();
            this.numberOfPeople = 0;

        }

        public string GetFreeTableInfo()
        {
            StringBuilder tableInfo = new StringBuilder();
            tableInfo.AppendLine($"Table: {this.TableNumber}");
            tableInfo.AppendLine($"Type: {this.GetType().Name}");
            tableInfo.AppendLine($"Capacity: {this.Capacity}");
            tableInfo.AppendLine($"Price per Person: {this.PricePerPerson}");
            return tableInfo.ToString().TrimEnd();
        }
    }
}
