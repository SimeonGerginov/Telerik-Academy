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
    public class CreateProjectCommand : CreateCommand, ICommand
    {
        public CreateProjectCommand(IDatabase database, IModelsFactory factory)
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

            string projectName = parameters[0];
            string startingDate = parameters[1];
            string endingDate = parameters[2];
            string state = parameters[3];

            if (this.Database.Projects.Any(p => p.Name == projectName))
            {
                throw new UserValidationException("A project with that name already exists!");
            }

            IProject project = this.Factory.CreateProject(projectName, startingDate, endingDate, state);
            this.Database.Projects.Add(project);

            return "Successfully created a new project!";
        }
    }
}
