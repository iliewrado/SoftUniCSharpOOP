using System;
using System.Collections.Generic;
using System.Linq;

namespace _05FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;
        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public int Rating()
        {
            int result = 0;
            if (players.Count > 0)
            {
                result = (int)players
                    .Average(x => Math.Round(x.PlayerStats()));
            }
            return result;
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
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void RemovePlayer(string player)
        {
            int index = players.FindIndex(x => x.Name.Equals(player));
            if (index < 0)
            {
                throw new ArgumentException($"Player {player} is not in {Name} team.");
            }
            players.RemoveAt(index);
        }
    }
}
