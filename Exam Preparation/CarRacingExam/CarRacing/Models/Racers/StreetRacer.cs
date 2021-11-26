using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int experience = 10;
        private const string behavior = "aggressive";

        public StreetRacer(string username, ICar car)
            : base(username, behavior, experience, car)
        {
        }

        public override void Race()
        {
            this.DrivingExperience += 5;
            base.Race();
        }

        public override bool IsAvailable()
        {
            return base.IsAvailable();
        }
    }
}
