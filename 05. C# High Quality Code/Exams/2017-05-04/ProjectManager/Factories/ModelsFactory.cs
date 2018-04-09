using System;
using Bytes2you.Validation;

using ProjectManager.Common.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Enums;
using ProjectManager.Factories.Contracts;
using ProjectManager.Models;
using ProjectManager.Models.Contracts;

namespace ProjectManager.Factories
{
    public class ModelsFactory : IModelsFactory
    {
        private readonly IValidator validator;

        public ModelsFactory(IValidator validator)
        {
            Guard.WhenArgument(validator, "Validator").IsNull().Throw();

            this.validator = validator;
        }

        public IProject CreateProject(string name, string startingDate, string endingDate, string state)
        {
            DateTime startDateParsed;
            DateTime endDateParsed;
            ProjectState stateParsed;

            bool startingDateSuccessful = DateTime.TryParse(startingDate, out startDateParsed);
            bool endingDateSuccessful = DateTime.TryParse(endingDate, out endDateParsed);
            bool stateSuccessful = Enum.TryParse(state, true, out stateParsed);

            if (!startingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed starting date!");
            }

            if (!endingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed ending date!");
            }

            if (!stateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed state!");
            }

            IProject project = new Project(name, startDateParsed, endDateParsed, stateParsed);
            this.validator.Validate(project);

            return project;
        }

        public ITask CreateTask(IUser owner, string name, string state)
        {
            TaskState stateParsed;
            bool stateSuccessful = Enum.TryParse(state, true, out stateParsed);

            if (!stateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed state!");
            }

            ITask task = new Task(name, owner, stateParsed);
            validator.Validate(task);

            return task;
        }

        public IUser CreateUser(string username, string email)
        {
            IUser user = new User(username, email);
            validator.Validate(user);

            return user;
        }       
    }
}
