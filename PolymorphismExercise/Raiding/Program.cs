using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                switch (heroType)
                {
                    case "Druid":
                        Druid druid = new Druid(heroName);
                        heroes.Add(druid);
                        break;
                    case "Paladin":
                        Paladin paladin = new Paladin(heroName);
                        heroes.Add(paladin);
                        break;
                    case "Rogue":
                        Rogue rogue = new Rogue(heroName);
                        heroes.Add(rogue);
                        break;
                    case "Warrior":
                        Warrior warrior = new Warrior(heroName);
                        heroes.Add(warrior);
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        i--;
                        break;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int heroesPower = heroes.Sum(x => x.Power);

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }
            Console.WriteLine(heroesPower >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}
