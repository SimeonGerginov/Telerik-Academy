using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        private readonly IRemoveStudent removeStudent;

        public RemoveStudentCommand(IRemoveStudent removeStudent)
        {
            this.removeStudent = removeStudent;
        }

        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);

            this.removeStudent.RemoveStudent(studentId);
            return $"Student with ID {studentId} was sucessfully removed.";
        }
    }
}
