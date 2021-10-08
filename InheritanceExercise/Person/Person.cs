using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string Name;
        private int Age;
        public string name { get; set; }
        public int age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
