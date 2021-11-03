using System;
namespace MilitaryElite.Classes
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firsName, string lastName, int codeNumber)
            : base(id, firsName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()}{Environment.NewLine}Code Number: {CodeNumber}";
        }
    }
}
