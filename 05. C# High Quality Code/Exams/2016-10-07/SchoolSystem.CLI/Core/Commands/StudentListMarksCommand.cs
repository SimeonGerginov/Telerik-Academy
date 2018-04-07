using System.Collections.Generic;

using SchoolSystem.CLI.Core.Contracts;
using SchoolSystem.CLI.Models.Contracts;

namespace SchoolSystem.CLI.Core.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            int studentId = int.Parse(parameters[0]);
            IStudent student = Engine.Students[studentId];

            return student.ListMarks();
        }
    }
}
