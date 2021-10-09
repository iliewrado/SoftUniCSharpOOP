using System;
using System.Collections.Generic;

namespace _03ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] personsInfo = InputSpliter();
            string[] productsInfo = InputSpliter();

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                foreach (var item in personsInfo)
                {
                    string[] temp = item.Split('=');
                    Person person = new Person(temp[0], double.Parse(temp[1]));
                    people.Add(person);
                }
                foreach (var item in productsInfo)
                {
                    string[] temp = ItemSplit(item);
                    Product product = new Product(temp[0], double.Parse(temp[1]));
                    products.Add(product);
                }
                string input = string.Empty;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] temp = ItemSplit(input);

                    int index = people.FindIndex(x => x.Name == temp[0]);
                    int productIndex = products.FindIndex(x => x.Name == temp[1]);
                    people[index].AddProduct(products[productIndex]);
                }
                foreach (var person in people)
                {
                    Console.WriteLine(person.ToString());
                }

            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private static string[] ItemSplit(string item)
        {
            return item
                .Split(new char[] { '=', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string[] InputSpliter()
        {
            return Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
