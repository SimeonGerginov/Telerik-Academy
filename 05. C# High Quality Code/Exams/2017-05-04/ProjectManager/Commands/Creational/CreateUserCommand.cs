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
    public class CreateUserCommand : CreateCommand, ICommand
    {
        public CreateUserCommand(IDatabase database, IModelsFactory factory)
            : base(database, factory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            if (parameters.Count != 3)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(p => p == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            int projectId = int.Parse(parameters[0]);
            string username = parameters[1];
            string email = parameters[2];

            if (this.database.Projects[projectId] == null)
            {
                throw new UserValidationException("Project with the passed id is not found in the database!");
            }

            if (this.database.Projects[projectId].Users.Any() && 
                this.database.Projects[projectId].Users.Any(u => u.Username == username))
            {
                throw new UserValidationException("A user with that username already exists!");
            }

            IUser user = this.factory.CreateUser(username, email);
            this.database.Projects[projectId].Users.Add(user);

            return "Successfully created a new user!";
        }
    }
}
