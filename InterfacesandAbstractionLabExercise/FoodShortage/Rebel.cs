using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Rebel : IPerson, IBuyer
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public int Food { get; set; }

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = 0;
        }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
