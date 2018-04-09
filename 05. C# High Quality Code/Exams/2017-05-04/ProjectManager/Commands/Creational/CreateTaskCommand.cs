using System.Collections.Generic;
using System.Linq;

using ProjectManager.Commands.Abstract;
using ProjectManager.Commands.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Factories.Contracts;
using ProjectManager.Models.Contracts;

namespace ProjectManager.Commands.Creational
{
    public class CreateTaskCommand : CreateCommand, ICommand
    {
        public CreateTaskCommand(IDatabase database, IModelsFactory factory)
            : base(database, factory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
           
            if (parameters.Count != 4)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(p => p == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            int projectId = int.Parse(parameters[0]);
            int ownerId = int.Parse(parameters[1]);
            string name = parameters[2];
            string state = parameters[3];

            IProject project;
            IUser owner;

            if (this.database.Projects[projectId] == null)
            {
                throw new UserValidationException("Project is not found in the database!");
            }

            project = this.database.Projects[projectId];

            if (project.Users[ownerId] == null)
            {
                throw new UserValidationException("User is not found in the database!");
            }

            owner = project.Users[ownerId];

            ITask task = this.factory.CreateTask(owner, name, state);
            project.Tasks.Add(task);

            return "Successfully created a new task!";
        }
    }
}
