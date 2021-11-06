using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = ReadInfo();
            string[] truckInfo = ReadInfo();
            int count = int.Parse(Console.ReadLine());
            
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));
            
            for (int i = 0; i < count; i++)
            {
                string[] cocommands = ReadInfo();
                double value = double.Parse(cocommands[2]);

                if (cocommands[0] == "Drive")
                {
                    if (cocommands[1] == "Car")
                    {
                        car.Drive(value);
                    }
                    else if (cocommands[1] == "Truck")
                    {
                        truck.Drive(value);
                    }
                }
                else if (cocommands[0] == "Refuel")
                {
                    if (cocommands[1] == "Car")
                    {
                        car.Refuel(value);
                    }
                    else if (cocommands[1] == "Truck")
                    {
                        truck.Refuel(value);
                    }
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }

        private static string[] ReadInfo()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
