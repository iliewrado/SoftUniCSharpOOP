﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double DefaultFuelConsumption = 3;
        public override double FuelConsumption
        {
            get
            {
                return DefaultFuelConsumption;
            }
        }
        public Car(int horsePower, double fuel)
            :base(horsePower,fuel)
        {

        }
    }
}
