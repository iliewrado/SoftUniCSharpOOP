using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double initialFuelAvailable = 65;
        private const double consumptionPerRace = 7.5;
        public TunedCar(string make, string model, string VIN, int horsePower)
            : base(make, model, VIN, horsePower, initialFuelAvailable, consumptionPerRace)
        {
        }

        public override void Drive()
        {
            this.HorsePower -= (int)Math.Round(this.HorsePower * 0.03);
            base.Drive();
        }
    }
}
