﻿using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public abstract class Decoration : IDecoration
    {
        public int Comfort { get; }

        public decimal Price { get; }

        protected Decoration(int comfort, decimal price)
        {
            Comfort = comfort;
            Price = price;
        }
    }
}
