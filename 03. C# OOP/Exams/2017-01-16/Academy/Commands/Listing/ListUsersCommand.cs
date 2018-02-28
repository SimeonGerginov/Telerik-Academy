﻿namespace Academy.Commands.Listing
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Academy.Commands.Contracts;
    using Academy.Core.Contracts;

    public class ListUsersCommand : ICommand
    {
        private const string ErrorMessage = "There are no registered users!";

        private readonly IAcademyFactory factory;
        private readonly IEngine engine;

        public ListUsersCommand(IAcademyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            StringBuilder sb = new StringBuilder();

            if (this.engine.Trainers.Count == 0)
            {
                throw new ArgumentException(ErrorMessage);
            }

            foreach (var trainer in this.engine.Trainers)
            {
                sb.Append(trainer.ToString());
            }

            if (this.engine.Students.Count == 0)
            {
                throw new ArgumentException(ErrorMessage);
            }

            foreach (var student in this.engine.Students)
            {
                sb.Append(student.ToString());
            }

            return sb.ToString();
        }
    }
}
