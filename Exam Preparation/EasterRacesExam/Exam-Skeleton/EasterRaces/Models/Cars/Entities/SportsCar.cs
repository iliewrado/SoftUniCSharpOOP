using EasterRaces.Models.Cars.Contracts;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double baseCubicCentimeters = 3000;
        private const int baseMinHorsePower = 250;
        private const int baseMaxHorsePower = 450;
        public SportsCar(string model, int horsePower)
            : base(model, horsePower, baseCubicCentimeters, baseMinHorsePower, baseMaxHorsePower)
        {
        }
    }
}
