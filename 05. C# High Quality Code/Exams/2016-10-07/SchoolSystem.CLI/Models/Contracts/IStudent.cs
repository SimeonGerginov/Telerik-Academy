using System.Collections.Generic;
using SchoolSystem.CLI.Enums;

namespace SchoolSystem.CLI.Models.Contracts
{
    /// <summary>
    /// Represens a Student and extends a Person, has a Grade, a collection of Marks and a way of displaying those marks.
    /// </summary>
    public interface IStudent
    {
        Grade Grade { get; set; }

        IList<IMark> Marks { get; set; }

        /// <summary>
        /// Generates a list of the student's marks in a specific format.
        /// </summary>
        /// <returns>Returns a string, formatted as a list of marks. If there are no marks, it returns an appropriate error message.</returns>
        string ListMarks();
    }
}
