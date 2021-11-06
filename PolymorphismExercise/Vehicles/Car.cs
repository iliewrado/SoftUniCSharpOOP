using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double increase = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
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
            FuelQuantity += amount;
        }
    }
}
