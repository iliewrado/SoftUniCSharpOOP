using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Plant :Decoration
    {
        private const int baseComfort = 5;
        private const decimal basePrice = 10;

        public Plant()
            :base(baseComfort, basePrice)
        {

        }
    }
}
