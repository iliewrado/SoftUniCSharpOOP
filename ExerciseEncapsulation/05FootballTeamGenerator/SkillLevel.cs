using System;
namespace _05FootballTeamGenerator
{
    public class SkillLevel
    {
        private const int minLevel = 0;
        private const int maxLevel = 100;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public SkillLevel(params int[] skills)
        {
            Endurance = skills[0];
            Sprint = skills[1];
            Dribble = skills[2];
            Passing = skills[3];
            Shooting = skills[4];
        }
        public int Shooting
        {
            get { return shooting; }
            private set 
            {
                if (value < minLevel || value > maxLevel)
                {
                    throw new ArgumentException("Shooting should be between 0 and 100.");
                }
                shooting = value; 
            }
        }

        public int Passing
        {
            get { return passing; }
            private set 
            {
                if (value < minLevel || value > maxLevel)
                {
                    throw new ArgumentException("Passing should be between 0 and 100.");
                }
                passing = value; 
            }
        }

        public int Dribble
        {
            get { return dribble; }
            private set
            {
                if (value < minLevel || value > maxLevel)
                {
                    throw new ArgumentException("Dribble should be between 0 and 100.");
                }
                dribble = value;
            }
        }

        public int Sprint
        {
            get { return sprint; }
            private set
            {
                if (value < minLevel || value > maxLevel)
                {
                    throw new ArgumentException("Sprint should be between 0 and 100.");
                }
                sprint = value;
            }
        }

        public int Endurance
        {
            get { return endurance; }
            private set 
            {
                if (value < minLevel || value > maxLevel)
                {
                    throw new ArgumentException("Endurance should be between 0 and 100.");
                }
                endurance = value; 
            }
        }
    }
}
