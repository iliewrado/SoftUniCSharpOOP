using EasterRaces.Models.Cars.Contracts;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double baseCubicCentimeters = 5000;
        private const int baseMinHorsePower = 400;
        private const int baseMaxHorsePower = 600;

        public MuscleCar(string model, int horsePower)
            : base(model, horsePower, baseCubicCentimeters,
                  baseMinHorsePower, baseMaxHorsePower)
        {
        }
    }
}
