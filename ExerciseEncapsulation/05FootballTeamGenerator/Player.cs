using System;
using System.Collections.Generic;
using System.Text;
namespace _05FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private SkillLevel stats; 
        public Player(string name, SkillLevel skills)
        {
            Name = name;
            Stats = skills;
        }
        public SkillLevel Stats
        {
            get { return stats; }
            private set { stats = value; }
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value; 
            }
        }
        public double PlayerStats()
        {
            return (stats.Dribble + stats.Endurance + stats.Passing + stats.Shooting + stats.Sprint) / 5.0;
        }
    }
}
