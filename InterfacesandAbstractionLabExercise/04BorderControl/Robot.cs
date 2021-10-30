using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : IRobots, IIdentifiable
    {
        public string Id { get; set; }
        public string Model { get; set; }
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }
    }
}
