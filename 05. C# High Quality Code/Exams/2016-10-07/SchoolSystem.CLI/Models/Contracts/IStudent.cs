using System.Collections.Generic;
using SchoolSystem.CLI.Enums;

namespace SchoolSystem.CLI.Models.Contracts
{
    public interface IStudent
    {
        Grade Grade { get; set; }

        IList<IMark> Marks { get; set; }

        string ListMarks();
    }
}
