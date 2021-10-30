using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < count; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(new char[] { '<', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (info.Length == 4)
                {
                    Citizen citizen = new Citizen(info[0], int.Parse(info[1]), info[2], info[3]);
                    buyers.Add(citizen);
                }
                else if(info.Length == 3)
                {
                    Rebel rebel = new Rebel(info[0], int.Parse(info[1]), info[2]);
                    buyers.Add(rebel);
                }
            }
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                if (buyers.Exists(x => x.Name == input))
                {
                    int index = buyers.FindIndex(x => x.Name == input);
                    buyers[index].BuyFood();
                }
            }

            Console.WriteLine(buyers.Sum(x => x.Food));
        }
    }
}
