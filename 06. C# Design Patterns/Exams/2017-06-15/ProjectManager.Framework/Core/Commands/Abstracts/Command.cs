using System.Collections.Generic;
using Bytes2you.Validation;

using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Data;

namespace ProjectManager.Framework.Core.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        private readonly IDatabase database;

        public Command(IDatabase database)
        {
            Guard.WhenArgument(database, "Database").IsNull().Throw();
            this.database = database;
        }

        public abstract int ParameterCount
        {
            get;
        }

        protected IDatabase Database
        {
            get
            {
                return this.database;
            }
        }

        public abstract string Execute(IList<string> parameters);
    }
}
