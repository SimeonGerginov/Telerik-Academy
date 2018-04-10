using ProjectManager.Commands.Contracts;
using ProjectManager.Commands.Creational;
using ProjectManager.Commands.Listing;
using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Providers;
using ProjectManager.Data;
using ProjectManager.Factories;
using ProjectManager.Factories.Contracts;

namespace ProjectManager.Commands
{
    public class CommandsFactory : ICommandsFactory
    {
        private readonly IDatabase database;
        private readonly IModelsFactory modelsFactory;

        public CommandsFactory(IDatabase database, IModelsFactory factory)
        {
            this.database = database ?? new Database();
            this.modelsFactory = factory ?? new ModelsFactory(new Validator());
        }

        public ICommand CreateCommandFromString(string commandName)
        {
            switch (commandName.ToLower())
            {
               case "createproject":
                    return this.CreateProjectCommand();
               case "createtask":
                    return this.CreateTaskCommand();
                case "createuser":
                    return this.CreateUserCommand();
                case "listprojects":
                    return this.ListProjects();
                case "listprojectdetails":
                    return this.ListProjectDetails();
               default: throw new UserValidationException("The passed command is not valid!");
            }
        }

        public ICommand CreateProjectCommand()
        {
            return new CreateProjectCommand(this.database, this.modelsFactory);
        }

        public ICommand CreateTaskCommand()
        {
            return new CreateTaskCommand(this.database, this.modelsFactory);
        }

        public ICommand CreateUserCommand()
        {
            return new CreateUserCommand(this.database, this.modelsFactory);
        }

        public ICommand ListProjectDetails()
        {
            return new ListProjectDetailsCommand(this.database);
        }

        public ICommand ListProjects()
        {
            return new ListProjectsCommand(this.database);
        }
    }
}
