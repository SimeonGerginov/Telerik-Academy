using System;
using System.Collections.Generic;

using SchoolSystem.CLI.Constants;
using SchoolSystem.CLI.Core.Contracts;
using SchoolSystem.CLI.Models;

namespace SchoolSystem.CLI.Core.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            int teacherId = int.Parse(parameters[0]);
            int studentId = int.Parse(parameters[1]);
            float value = float.Parse(parameters[2]);

            if (Engine.Students.ContainsKey(studentId) && Engine.Teachers.ContainsKey(teacherId))
            {
                Student student = Engine.Students[studentId];
                Teacher teacher = Engine.Teachers[teacherId];

                teacher.AddMark(student, value);

                return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {value} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
            }
            else
            {
                throw new ArgumentException(GlobalConstants.NotFoundPersonErrorMessage);
            }
        }
    }
}
