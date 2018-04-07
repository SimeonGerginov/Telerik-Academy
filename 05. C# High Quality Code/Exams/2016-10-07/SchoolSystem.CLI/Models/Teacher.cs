using System;

using SchoolSystem.CLI.Constants;
using SchoolSystem.CLI.Enums;
using SchoolSystem.CLI.Models.Abstractions;
using SchoolSystem.CLI.Models.Contracts;

namespace SchoolSystem.CLI.Models
{
    public class Teacher : Person, ITeacher
    {
        private Subject subject;

        public Teacher(string firstName, string lastName, Subject subject)
            : base(firstName, lastName)
        {
            this.Subject = subject;
        }

        public Subject Subject
        {
            get
            {
                return this.subject;
            }

            set
            {
                this.subject = value;
            }
        }

        public void AddMark(IStudent student, float value)
        {
            if (student.Marks.Count == GlobalConstants.MaxMarkCountPerStudent)
            {
                throw new ArgumentException(GlobalConstants.MarkCountErrorMessage);
            }

            Subject subjectOfTeacher = this.Subject;
            IMark mark = new Mark(value, subjectOfTeacher);

            student.Marks.Add(mark);
        }
    }
}
