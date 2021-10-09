using System;
using System.Collections.Generic;

namespace _05FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] info = input
                    .Split(';');
                    switch (info[0])
                    {
                        case "Team":
                            Team team = new Team(info[1]);
                            teams.Add(team);
                            break;
                        case "Add":
                            CheckAddPlayer(teams, info);
                            break;
                        case "Remove":
                            CheckRemovePlayer(teams, info);
                            break;
                        case "Rating":
                            PrintRating(teams, info[1]);
                            break;
                    }
                }
                catch (Exception aeEX)
                {
                    Console.WriteLine(aeEX.Message);
                }
            }
        }

        private static void CheckRemovePlayer(List<Team> teams, string[] info)
        {
            int index = teams.FindIndex(x => x.Name.Equals(info[1]));
            if (index >= 0)
            {
                teams[index].RemovePlayer(info[2]);
            }
            else
            {
                throw new ArgumentException($"Team {info[1]} does not exist.");
            }
        }

        private static void CheckAddPlayer(List<Team> teams, string[] info)
        {
            SkillLevel skills = new SkillLevel
                (new int[] {int.Parse(info[3]),
                    int.Parse(info[4]), int.Parse(info[5]),
                    int.Parse(info[6]), int.Parse(info[7])});
            Player player = new Player(info[2], skills);
            int index = teams.FindIndex(x => x.Name.Equals(info[1]));
            if (index >= 0)
            {
                teams[index].AddPlayer(player);
            }
            else
            {
                throw new ArgumentException($"Team {info[1]} does not exist.");
            }
        }
        private static void PrintRating(List<Team> teams, string teamName)
        {
            int index = teams.FindIndex(x => x.Name.Equals(teamName));
            if (index >= 0)
            {
                Console.WriteLine($"{teams[index].Name} - {teams[index].Rating()}");
            }
            else
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
        }
    }
}