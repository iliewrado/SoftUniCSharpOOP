using System;
namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double increase = 1.6;

        public Truck(double tankCapacity, double fuelQuantity, double fuelConsumption)
            : base(tankCapacity, fuelQuantity, fuelConsumption)
        {
        }

        public override void Drive(double distance)
        {
            double consumption = distance * (FuelConsumption + increase);
            if (FuelQuantity >= consumption)
            {
                FuelQuantity -= consumption;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Truck needs refueling");
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
                    FuelQuantity += amount * 0.95;
                }
            }
        }
    }
}
