using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Animals.Birds;
using WildFarm.Animals.Mammals;
using WildFarm.Animals.Mammals.Felines;
using WildFarm.Foods;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            Food food = null;
            Animal animal = null;
            List<Animal> animals = new List<Animal>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalInfo = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string[] foodInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                food = GetFood(foodInfo);
                animal = GetAnimal(animalInfo);
                Console.WriteLine(animal.ProduceSound());
                animal.Eat(food);
                animals.Add(animal);
            }

            foreach (var beast in animals)
            {
                Console.WriteLine(beast.ToString());
            }
        }

        private static Animal GetAnimal(string[] animalInfo)
        {
            Animal animal = null;
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);
            switch (animalInfo[0])
            {
                case "Cat":
                    string region = animalInfo[3];
                    string breed = animalInfo[4];
                    animal = new Cat(name, weight, region, breed);
                    break;
                case "Dog":
                    region = animalInfo[3];
                    animal = new Dog(name, weight, region);
                    break;
                case "Mouse":
                    region = animalInfo[3];
                    animal = new Mouse(name, weight, region);
                    break;
                case "Hen":
                    double wings = double.Parse(animalInfo[3]);
                    animal = new Hen(name, weight, wings);
                    break;
                case "Owl":
                    wings = double.Parse(animalInfo[3]);
                    animal = new Owl(name, weight, wings);
                    break;
                case "Tiger":
                    region = animalInfo[3];
                    breed = animalInfo[4];
                    animal = new Tiger(name, weight, region, breed);
                    break;
            }

            return animal;
        }

        private static Food GetFood(string[] foodInfo)
        {
            Food food = null;

            switch (foodInfo[0])
            {
                case "Vegetable":
                    food = new Vegetable(int.Parse(foodInfo[1]));
                    break;
                case "Fruit":
                    food = new Fruit(int.Parse(foodInfo[1]));
                    break;
                case "Meat":
                    food = new Meat(int.Parse(foodInfo[1]));
                    break;
                case "Seeds":
                    food = new Seeds(int.Parse(foodInfo[1]));
                    break;
            }

            return food;
        }
    }
}
