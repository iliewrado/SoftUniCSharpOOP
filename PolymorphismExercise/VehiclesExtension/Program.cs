using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = null;
            Vehicle truck = null;
            Bus bus = null;

            for (int i = 0; i < 3; i++)
            {
                string[] vehicleInfo = ReadInfo();
                switch (vehicleInfo[0])
                {
                    case"Car":
                        car = new Car
                            (double.Parse(vehicleInfo[3]), 
                            double.Parse(vehicleInfo[1]), 
                            double.Parse(vehicleInfo[2]));
                        break;
                    case "Truck":
                        truck = new Truck
                            (double.Parse(vehicleInfo[3]),
                            double.Parse(vehicleInfo[1]), 
                            double.Parse(vehicleInfo[2]));
                        break;
                    case "Bus":
                        bus = new Bus
                            (double.Parse(vehicleInfo[3]),
                            double.Parse(vehicleInfo[1]), 
                            double.Parse(vehicleInfo[2]));
                        break;
                }
            }

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] commands = ReadInfo();
                double value = double.Parse(commands[2]);
                if (commands[0] == "Drive")
                {
                    switch (commands[1])
                    {
                        case "Car":
                            car.Drive(value);
                            break;
                        case "Truck":
                            truck.Drive(value);
                            break;
                        case "Bus":
                            bus.Drive(value);
                            break;
                    }
                }
                else if (commands[0] == "Refuel")
                {
                    switch (commands[1])
                    {
                        case "Car":
                            car.Refuel(value);
                            break;
                        case "Truck":
                            truck.Refuel(value);
                            break;
                        case "Bus":
                            bus.Refuel(value);
                            break;
                    }
                }
                else if (commands[0] == "DriveEmpty")
                {
                    bus.DriveEmpty(double.Parse(commands[2]));
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }

        private static string[] ReadInfo()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
