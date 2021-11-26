using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages
                    .OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages
                    .OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else if (racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                racerOne.Race();
                racerTwo.Race();
                double racerOnePoints = ChanceOfWinning(racerOne);
                double racerTwoPoints = ChanceOfWinning(racerTwo);
                string winnerName = string.Empty;
                if (racerOnePoints > racerTwoPoints)
                {
                    winnerName = racerOne.Username;
                }
                else
                {
                    winnerName = racerTwo.Username;
                }

                return string.Format(OutputMessages
                    .RacerWinsRace, racerOne.Username, racerTwo.Username, winnerName);
            }
            else
            {
                return string.Format(OutputMessages.RaceCannotBeCompleted);
            }
        }

        private double ChanceOfWinning(IRacer racer)
        {
            return racer.Car.HorsePower * racer.DrivingExperience * RacingBehaviorMultiplier(racer);
        }

        private double RacingBehaviorMultiplier(IRacer racer)
        {
            if (racer.RacingBehavior == "strict")
            {
                return 1.2;
            }
            else
            {
                return 1.1;
            }
        }
    }
}
