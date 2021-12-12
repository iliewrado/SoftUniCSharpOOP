using Gym.Models.Equipment.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public abstract class Equipment : IEquipment
    {
        public double Weight { get; }
        public decimal Price { get; }

        public Equipment(double weight, decimal price)
        {
            Weight = weight;
            Price = price;
        }
    }
}
