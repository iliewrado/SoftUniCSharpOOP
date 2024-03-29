﻿namespace BorderControl
{
    public class Citizen : IIdentifiable, IPerson
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }
    }
}
