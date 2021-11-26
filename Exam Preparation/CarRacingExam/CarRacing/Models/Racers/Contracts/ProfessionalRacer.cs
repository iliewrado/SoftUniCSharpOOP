using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers.Contracts
{
    public class ProfessionalRacer : Racer
    {
        private const int experience = 30;
        private const string behavior = "strict";

        public ProfessionalRacer(string username, ICar car)
            : base(username, behavior, experience, car)
        {
        }

        public override void Race()
        {
            this.DrivingExperience += 10;
            base.Race();
        }

        public override bool IsAvailable()
        {
            return base.IsAvailable();
        }
    }
}
