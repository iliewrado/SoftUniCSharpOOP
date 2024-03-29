﻿using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                string result = this.commandInterpreter.Read(input);

                if (result == null)
                {
                    break;
                }

                Console.WriteLine(result);
            }
        }
    }
}
