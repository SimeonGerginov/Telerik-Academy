using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using SchoolSystem.CLI.Core.Contracts;

namespace SchoolSystem.CLI.Core.Providers
{
    public class CommandParserProvider : IParser
    {
        public ICommand ParseCommand(string fullCommand)
        {
            string commandName = fullCommand.Split(' ')[0];
            TypeInfo commandTypeInfo = this.FindCommand(commandName);
            ICommand command = Activator.CreateInstance(commandTypeInfo) as ICommand;

            return command;
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            List<string> commandParts = fullCommand.Split(' ').ToList();
            commandParts.RemoveAt(0);

            if (commandParts.Count == 0)
            {
                return null;
            }

            return commandParts;
        }

        private TypeInfo FindCommand(string commandName)
        {
            Assembly currentAssembly = this.GetType().GetTypeInfo().Assembly;
            TypeInfo commandTypeInfo = currentAssembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                .SingleOrDefault();

            if (commandTypeInfo == null)
            {
                throw new ArgumentNullException("The passed command is not found!");
            }

            return commandTypeInfo;
        }
    }
}
