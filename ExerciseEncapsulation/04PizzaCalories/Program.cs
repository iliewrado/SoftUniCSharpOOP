using System;

namespace _04PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaName = Console.ReadLine()
                    .Split(' ');
                string[] doughInfo = Console.ReadLine()
                    .Split(' ');
                Dough dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));
                Pizza pizza = new Pizza(pizzaName[1], dough);
                string input = string.Empty;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingInfo = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Topping topping = new Topping(toppingInfo[1], double.Parse(toppingInfo[2]));
                    pizza.AddTopping(topping);
                }
                Console.WriteLine(pizza.ToString());
            }
            catch (Exception arEx)
            {
                Console.WriteLine(arEx.Message);
            }


        }
    }
}
