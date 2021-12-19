using System;
using WorkShopDi.Contracts;

namespace WorkShopDi.Services
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
