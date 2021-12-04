﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish.Contracts
{
    public class SaltwaterFish : Fish
    {
        private int size;

        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.size = 5;
        }

        public override void Eat()
        {
            this.size += 2;
        }
    }
}
