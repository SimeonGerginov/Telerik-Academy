using System.Collections.Generic;

using SchoolSystem.CLI.Enums;
using SchoolSystem.CLI.Models.Abstractions;
using SchoolSystem.CLI.Models.Contracts;

namespace SchoolSystem.CLI.Models
{
    public class Student : Person, IStudent
    {
        private Grade grade;
        private IList<IMark> marks;

        public Student(string firstName, string lastName, Grade grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
            this.Marks = new List<IMark>();
        }

        public Grade Grade
        {
            get
            {
                return this.grade;
            }

            set
            {
                this.grade = value;
            }
        }

        public IList<IMark> Marks
        {
            get
            {
                return this.marks;
            }

            set
            {
                this.marks = value;
            }
        }
    }
}
