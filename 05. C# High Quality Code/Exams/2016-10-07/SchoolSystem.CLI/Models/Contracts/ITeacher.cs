using SchoolSystem.CLI.Enums;

namespace SchoolSystem.CLI.Models.Contracts
{
    /// <summary>
    /// Represents a Teacher and extends Person, has a Subject and a way of assinging Marks to Students.
    /// </summary>
    public interface ITeacher : IPerson
    {
        Subject Subject { get; set; }

        /// <summary>
        /// Adds a mark to a given student.
        /// </summary>
        /// <param name="student">The student, who will recieve the mark.</param>
        /// <param name="value">The mark value itself that can be between 2.00 and 6.00</param>
        void AddMark(IStudent student, float value);
    }
}
