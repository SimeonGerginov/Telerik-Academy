using System.Collections.Generic;

using SchoolSystem.CLI.Core.Contracts;
using SchoolSystem.CLI.Enums;
using SchoolSystem.CLI.Models;
using SchoolSystem.CLI.Models.Contracts;

namespace SchoolSystem.CLI.Core.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private static int currentTeacherId = 0;

        public string Execute(IList<string> parameters)
        {
            string firstName = parameters[0];
            string lastName = parameters[1];
            Subject subject = (Subject)int.Parse(parameters[2]);

            ITeacher teacher = new Teacher(firstName, lastName, subject);
            Engine.Teachers.Add(currentTeacherId, teacher);

            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {currentTeacherId++} was created.";
        }
    }
}
