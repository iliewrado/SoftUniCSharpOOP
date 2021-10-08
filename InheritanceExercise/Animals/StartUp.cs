using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                string[] animalInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    switch (input)
                    {
                        case "Cat":
                            Animal animal = new Cat(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                            animals.Add(animal);
                            break;
                        case "Kitten":
                            animal = new Kitten(animalInfo[0], int.Parse(animalInfo[1]));
                            animals.Add(animal);
                            break;
                        case "Tomcat":
                            animal = new Tomcat(animalInfo[0], int.Parse(animalInfo[1]));
                            animals.Add(animal);
                            break;
                        case "Dog":
                            animal = new Dog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                            animals.Add(animal);
                            break;
                        case "Frog":
                            animal = new Frog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                            animals.Add(animal);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
