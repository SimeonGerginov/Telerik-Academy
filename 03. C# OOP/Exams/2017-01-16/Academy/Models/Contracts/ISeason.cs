namespace Academy.Models.Contracts
{
    using System.Collections.Generic;

    using Academy.Models.Enums;

    public interface ISeason
    {
        Initiative Initiative { get; }

        int StartingYear { get; }

        int EndingYear { get; }

        IList<IStudent> Students { get; set; }

        IList<ITrainer> Trainers { get; set; }

        IList<ICourse> Courses { get; set; }

        string ListUsers();

        string ListCourses();
    }
}
