namespace Academy.Models.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface ILecture
    {
        string Name { get; }

        DateTime Date { get; }

        ITrainer Trainer { get; }

        IList<ILectureResource> Resources { get; }
    }
}
