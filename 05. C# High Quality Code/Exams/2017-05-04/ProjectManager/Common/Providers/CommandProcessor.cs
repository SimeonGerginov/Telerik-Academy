using System.Collections.Generic;
using System.Linq;

using ProjectManager.Commands;
using ProjectManager.Commands.Contracts;
using ProjectManager.Common.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Factories.Contracts;

namespace ProjectManager.Common.Providers
{
    public class CommandProcessor : ICommandProcessor
    {
        private static ICommandProcessor instance;

        private ICommandsFactory factory;

        private CommandProcessor(ICommandsFactory factory)
        {
            this.factory = factory ?? new CommandsFactory(null, null);
        }

        public static ICommandProcessor Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommandProcessor(null);
                }

                return instance;
            }
        }

        public string Process(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new UserValidationException("No command has been provided!");
            }

            string commandName = commandAsString.Split(' ')[0];
            IList<string> commandParameters = commandAsString
                .Split(' ')
                .Skip(1)
                .ToList();

            ICommand command = this.factory.CreateCommandFromString(commandName);
            string executionResult = command.Execute(commandParameters);

            return executionResult;
        }
    }
}
