using System;
using System.Collections.Generic;

using SchoolSystem.CLI.Constants;
using SchoolSystem.CLI.Core.Contracts;

namespace SchoolSystem.CLI.Core.Commands
{
    public class RemoveTeacherCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            int teacherId = int.Parse(parameters[0]);

            if (Engine.Teachers.ContainsKey(teacherId))
            {
                Engine.Teachers.Remove(teacherId);

                return $"Teacher with ID {teacherId} was sucessfully removed.";
            }
            else
            {
                throw new ArgumentException(GlobalConstants.KeyNotFoundErrorMessage);
            }
        }
    }
}
