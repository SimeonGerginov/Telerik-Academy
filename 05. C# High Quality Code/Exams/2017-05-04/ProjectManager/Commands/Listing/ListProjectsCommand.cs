using System;
using System.Collections.Generic;
using System.Linq;

using ProjectManager.Commands.Abstract;
using ProjectManager.Commands.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;

namespace ProjectManager.Commands.Listing
{
    public class ListProjectsCommand : ListCommand, ICommand
    {
        public ListProjectsCommand(IDatabase database)
            : base(database)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            if (parameters.Count != 0)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(p => p == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            return string.Join(Environment.NewLine, this.Database.Projects);
        }
    }
}
