using System.Collections.Generic;
using Bytes2you.Validation;

using ProjectManager.Commands.Contracts;
using ProjectManager.Data;

namespace ProjectManager.Commands.Abstract
{
    public abstract class ListCommand : ICommand
    {
        protected readonly IDatabase Database;

        public ListCommand(IDatabase database)
        {
            Guard.WhenArgument(database, "Database").IsNull().Throw();

            this.Database = database;
        }

        public abstract string Execute(IList<string> parameters);
    }
}
