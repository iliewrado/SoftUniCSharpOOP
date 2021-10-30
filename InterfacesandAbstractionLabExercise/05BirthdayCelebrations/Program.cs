using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthables = new List<IBirthable>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                switch (info[0])
                {
                    case"Citizen":
                        IBirthable citizen = 
                            new Citizen(info[1], int.Parse(info[2]), info[3], info[4]);
                        birthables.Add(citizen);
                        break;
                    //case "Robot":
                        //IBirthable robot = new Robot(info[1], info[2]);
                        //birthables.Add(robot);
                        //break;
                    case "Pet":
                        IBirthable pet = new Pet(info[1], info[2]);
                        birthables.Add(pet);
                        break;
                }
            }
            string year = Console.ReadLine();
            List<IBirthable> specificYear = birthables
                .Where(x => x.Birthdate.EndsWith(year))
                .ToList();
            if (specificYear.Count > 0)
            {
                specificYear.ForEach(x => Console.WriteLine(x.Birthdate));
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}
