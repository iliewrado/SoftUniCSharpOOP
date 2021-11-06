namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        protected Vehicle(double tankCapacity, double fuelQuantity, double fuelConsumption)
        {
            TankCapacity = tankCapacity;
            this.fuelQuantity = fuelQuantity > TankCapacity ? 0 : fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }

        public abstract void Drive(double distance);
        public abstract void Refuel(double amount);
    }
}
