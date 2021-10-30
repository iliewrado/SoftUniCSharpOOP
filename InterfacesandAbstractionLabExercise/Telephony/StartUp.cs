using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = ReadArray();
            string[] websites = ReadArray();

            foreach (var number in phoneNumbers)
            {
                if (number.Length == 10)
                {
                    Smartphone smartphone = new Smartphone();
                    smartphone.Calling(number);
                }
                else if (number.Length == 7)
                {
                    StationaryPhone stationaryPhone = new StationaryPhone();
                    stationaryPhone.Calling(number);
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
            foreach (var url in websites)
            {
                Smartphone smartphone = new Smartphone();
                smartphone.Browsing(url);
            }
        }

        private static string[] ReadArray()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
