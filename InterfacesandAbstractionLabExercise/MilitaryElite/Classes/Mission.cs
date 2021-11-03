using MilitaryElite.Enums;
using System;
namespace MilitaryElite.Classes
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionState missionState)
        {
            CodeName = codeName;
            MissionState = missionState;
        }

        public string CodeName { get; set; }
        public MissionState MissionState { get; set; }

        public void CompleteMission()
        {
            MissionState = MissionState.Finished;
        }
        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {MissionState}";
        }
    }
}
