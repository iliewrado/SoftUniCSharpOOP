using MilitaryElite.Classes;
using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Soldier> soldiers = new List<Soldier>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] soldierInfo = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string soldierType = soldierInfo[0];
                int id = int.Parse(soldierInfo[1]);
                string firstName = soldierInfo[2];
                string lastName = soldierInfo[3];

                switch (soldierType)
                {
                    case "Private":
                        decimal salary = decimal.Parse(soldierInfo[4]);
                        soldiers.Add(new Private(id, firstName, lastName, salary));
                        break;
                    case "LieutenantGeneral":
                        salary = decimal.Parse(soldierInfo[4]);
                        List<Private> privates = new List<Private>();
                        foreach (var currentId in soldierInfo.Skip(5))
                        {
                            Private currentPrivate = (Private)soldiers
                                .FirstOrDefault(x => x.Id == int.Parse(currentId));
                            if (currentPrivate != null)
                            {
                                privates.Add(currentPrivate);
                            }
                        }
                        soldiers.Add(new LieutenantGeneral(id, firstName, lastName, salary, privates));
                        break;
                    case "Engineer":
                        salary = decimal.Parse(soldierInfo[4]);
                        if (!Enum.TryParse(soldierInfo[5], out CorpEnum corp))
                        {
                            continue;
                        }
                        List<Repair> repairs = new List<Repair>();
                        for (int i = 6; i < soldierInfo.Length; i += 2)
                        {
                            string repairPart = soldierInfo[i];
                            int workedHours = int.Parse(soldierInfo[i + 1]);
                            repairs.Add(new Repair(repairPart, workedHours));
                        }
                        soldiers.Add(new Engineer(id, firstName, lastName, salary, corp, repairs));
                        break;
                    case "Commando":
                        salary = decimal.Parse(soldierInfo[4]);

                        if (!Enum.TryParse(soldierInfo[5], out corp))
                        {
                            continue;
                        }
                        List<Mission> missions = new List<Mission>();
                        for (int i = 6; i < soldierInfo.Length; i += 2)
                        {
                            string missionName = soldierInfo[i];
                            string missionState = soldierInfo[i + 1];
                            if (missionState != "inProgress" && missionState != "Finished")
                            {
                                continue;
                            }

                            if (Enum.TryParse(missionState, out MissionState state))
                            {
                                missions.Add(new Mission(missionName, state));
                            }
                        }
                        soldiers.Add(new Commando(id, firstName, lastName, salary, corp, missions));
                        break;
                    case "Spy":
                        int codeNumber = int.Parse(soldierInfo[4]);
                        soldiers.Add(new Spy(id, firstName, lastName, codeNumber));
                        break;
                }
            }

            foreach (var item in soldiers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
