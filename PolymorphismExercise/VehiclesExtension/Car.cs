using System;
namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double increase = 0.9;

        public Car(double tankCapacity, double fuelQuantity, double fuelConsumption)
            : base(tankCapacity, fuelQuantity, fuelConsumption)
        {
        }

        public override void Drive(double distance)
        {
            double consumption = distance * (FuelConsumption + increase);
            if (FuelQuantity >= consumption)
            {
                FuelQuantity -= consumption;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Car needs refueling");
            }
        }

        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                if (amount + FuelQuantity > TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {amount} fuel in the tank");
                }
                else
                {
                    FuelQuantity += amount;
                }
            }
        }
    }
}
