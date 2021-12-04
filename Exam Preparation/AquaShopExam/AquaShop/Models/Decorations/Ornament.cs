using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int baseComfort = 1;
        private const decimal basePrice = 5;
        public Ornament()
            : base(baseComfort, basePrice)
        {

        }
    }
}
