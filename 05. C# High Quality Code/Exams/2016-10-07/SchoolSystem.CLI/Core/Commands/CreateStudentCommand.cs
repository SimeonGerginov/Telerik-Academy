using System.Collections.Generic;

using SchoolSystem.CLI.Core.Contracts;
using SchoolSystem.CLI.Enums;
using SchoolSystem.CLI.Models;

namespace SchoolSystem.CLI.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private static int currentStudentId = 0;

        public string Execute(IList<string> parameters)
        {
            string firstName = parameters[0];
            string lastName = parameters[1];
            Grade grade = (Grade)int.Parse(parameters[2]);

            Student student = new Student(firstName, lastName, grade);
            Engine.Students.Add(currentStudentId, student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {currentStudentId++} was created.";
        }
    }
}
