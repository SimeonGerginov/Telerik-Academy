using System.Collections.Generic;
using System.Linq;

using ProjectManager.Commands.Abstract;
using ProjectManager.Commands.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Models.Contracts;

namespace ProjectManager.Commands.Listing
{
    public class ListProjectDetailsCommand : ListCommand, ICommand
    {
        public ListProjectDetailsCommand(IDatabase database) 
            : base(database)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            if (parameters.Count != 1)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(p => p == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            int projectId = int.Parse(parameters[0]);

            if (this.Database.Projects[projectId] == null)
            {
                throw new UserValidationException("There is no project with that id in the database!");
            }

            IProject project = this.Database.Projects[projectId];

            return project.ToString();
        }
    }
}
