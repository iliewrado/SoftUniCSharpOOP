using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Cars.Contracts
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;
        private int minHorsePower;
        private int maxHorsePower;

        public double CubicCentimeters
        {
            get { return cubicCentimeters; }
            private set 
            { 
                cubicCentimeters = value;
            }
        }

        public int HorsePower
        {
            get { return horsePower; }
            private set
            {
                if (value > this.maxHorsePower 
                    || value < this.minHorsePower)
                {
                    throw new ArgumentException
                        (string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                horsePower = value; 
            }
        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)
                    || value.Length < 4)
                {
                    throw new ArgumentException
                        (string.Format(ExceptionMessages.InvalidModel, value, 4));
                }
                model = value; 
            }
        }

        public Car(string model, int horsePower, double cubicCentimeters, 
            int minHorsePower, int maxHorsePower)
        {
            Model = model;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            CubicCentimeters = cubicCentimeters;
            HorsePower = horsePower;
        }

        public double CalculateRacePoints(int Laps)
        {
            return (double)this.CubicCentimeters / this.HorsePower * Laps;
        }
    }
}
