using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> citizens = new List<IIdentifiable>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (info.Length == 3)
                {
                    IIdentifiable person = new Citizen(info[0], int.Parse(info[1]), info[2]);
                    citizens.Add(person);
                }
                else if (info.Length == 2)
                {
                    IIdentifiable robot = new Robot(info[0], info[1]);
                    citizens.Add(robot);
                }
            }

            string fakeIds = Console.ReadLine();
            foreach (var citizen in citizens)
            {
                if (citizen.Id.EndsWith(fakeIds))
                {
                    Console.WriteLine(citizen.Id);
                }
            }
        }
    }
}
