using System;
using System.Collections.Generic;

using SchoolSystem.CLI.Constants;
using SchoolSystem.CLI.Core.Contracts;

namespace SchoolSystem.CLI.Core.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            int studentId = int.Parse(parameters[0]);

            if (Engine.Students.ContainsKey(studentId))
            {
                Engine.Students.Remove(studentId);

                return $"Student with ID {studentId} was sucessfully removed.";
            }
            else
            {
                throw new ArgumentException(GlobalConstants.KeyNotFoundErrorMessage);
            }
        }
    }
}
