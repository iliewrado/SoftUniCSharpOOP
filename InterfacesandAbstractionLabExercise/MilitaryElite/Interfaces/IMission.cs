using MilitaryElite.Enums;
namespace MilitaryElite
{
    public interface IMission
    {
        public string CodeName { get; set; }
        public MissionState MissionState { get; set; }
        public void CompleteMission();
    }
}