﻿namespace WildFarm.Foods
{
    public abstract class Food
    {
        public int Quantity { get; set; }
        public Food(int quantity)
        {
            Quantity = quantity;
        }
    }
}
