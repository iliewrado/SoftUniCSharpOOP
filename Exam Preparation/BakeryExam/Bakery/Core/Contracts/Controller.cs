using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core.Contracts
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        public decimal TotalIncome { get; private set; } = 0;
        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            switch (type)
            {
                case "Tea":
                    drinks.Add(new Tea(name, portion, brand));
                    break;
                case "Water":
                    drinks.Add(new Water(name, portion, brand));
                    break;
            }

            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            switch (type)
            {
                case "Bread":
                    bakedFoods.Add(new Bread(name, price));
                    break;
                case "Cake":
                    bakedFoods.Add(new Cake(name, price));
                    break;
            }
            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            switch (type)
            {
                case "InsideTable":
                    tables.Add(new InsideTable(tableNumber, capacity));
                    break;
                case "OutsideTable":
                    tables.Add(new OutsideTable(tableNumber, capacity));
                    break;
            }

            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder tableInfo = new StringBuilder();
            
            foreach (var table in tables.Where(x => x.IsReserved == false))
            {
                tableInfo.AppendLine(table.GetFreeTableInfo());
            }

            return tableInfo.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return string.Format(OutputMessages.TotalIncome, TotalIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            Table table = tables.FirstOrDefault(x => x.TableNumber == tableNumber) as Table;
            TotalIncome += table.GetBill();
            string result = string.Format($"Table: {tableNumber}" +
                $"{Environment.NewLine}Bill: {table.GetBill():f2}");
            table.Clear();
            return result;
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            Table table = tables.FirstOrDefault(x => x.TableNumber == tableNumber) as Table;

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            Drink drink = drinks.FirstOrDefault(x => x.Name == drinkName
            && x.Brand == drinkBrand) as Drink;

            if (drink == null)
            {
                return string.Format(OutputMessages
                    .NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            Table table = tables.FirstOrDefault(x => x.TableNumber == tableNumber) as Table;

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            BakedFood food = bakedFoods.FirstOrDefault(x => x.Name == foodName) as BakedFood;

            if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);

            return string.Format(OutputMessages
                .FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            Table table = tables.FirstOrDefault(x => x.Capacity > numberOfPeople
            && x.IsReserved == false) as Table;
            
            if (table == null)
            {
                return string.Format(OutputMessages
                    .ReservationNotPossible, numberOfPeople);
            }

            table.Reserve(numberOfPeople);

            return string.Format(OutputMessages.TableReserved,
                table.TableNumber, numberOfPeople);
        }
    }
}
