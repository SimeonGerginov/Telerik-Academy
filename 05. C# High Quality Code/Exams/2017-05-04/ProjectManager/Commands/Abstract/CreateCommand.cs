﻿using System.Collections.Generic;
using Bytes2you.Validation;

using ProjectManager.Commands.Contracts;
using ProjectManager.Data;
using ProjectManager.Factories.Contracts;

namespace ProjectManager.Commands.Abstract
{
    public abstract class CreateCommand : ICommand
    {
        protected readonly IDatabase Database;
        protected readonly IModelsFactory Factory;

        public CreateCommand(IDatabase database, IModelsFactory factory)
        {
            Guard.WhenArgument(database, "Database").IsNull().Throw();
            Guard.WhenArgument(factory, "Models Factory").IsNull().Throw();

            this.Database = database;
            this.Factory = factory;
        }

        public abstract string Execute(IList<string> parameters);
    }
}
