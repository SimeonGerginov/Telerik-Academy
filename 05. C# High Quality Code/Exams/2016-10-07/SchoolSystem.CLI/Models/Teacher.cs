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
    }
}
