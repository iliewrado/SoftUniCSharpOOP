using System;
using WorkShopDi.Contracts;

namespace WorkShopDi.Services
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
