using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Citizen citizen = new Citizen(info[0], info[1], int.Parse(info[2]));
                IPerson person = citizen;
                IResident resident = citizen;
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
