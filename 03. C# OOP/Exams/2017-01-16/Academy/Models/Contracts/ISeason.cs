using System.Collections.Generic;

using Academy.Models.Enums;

namespace Academy.Models.Contracts
{
    public interface ISeason
    {
        Initiative Initiative { get; set; }

        int StartingYear { get; set; }

        int EndingYear { get; set; }

        IList<IStudent> Students { get; set; }

        IList<ITrainer> Trainers { get; set; }

        IList<ICourse> Courses { get; set; }

        string ListUsers();

        string ListCourses();
    }
}
