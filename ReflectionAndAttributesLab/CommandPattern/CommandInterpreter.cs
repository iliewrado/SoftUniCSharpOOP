using System;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    using System.Linq;
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tockens = args
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string commandName = tockens[0];
            string[] commandArgs = tockens[1..];

            Type commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == $"{commandName}Command");
            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command Type");
            }

            ICommand command = (ICommand)Activator.CreateInstance(commandType);

            string result = command.Execute(commandArgs);
            return result;
        }
    }
}
