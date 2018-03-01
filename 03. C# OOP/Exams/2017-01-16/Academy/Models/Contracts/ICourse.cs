namespace Academy.Models.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface ICourse
    {
        string Name { get; }

        int LecturesPerWeek { get; }

        DateTime StartingDate { get; }

        DateTime EndingDate { get; }

        IList<IStudent> OnsiteStudents { get; }

        IList<IStudent> OnlineStudents { get; }

        IList<ILecture> Lectures { get; }
    }
}
