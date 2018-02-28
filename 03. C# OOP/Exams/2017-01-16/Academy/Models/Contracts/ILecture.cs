namespace Academy.Models.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface ILecture
    {
        string Name { get; set; }

        DateTime Date { get; set; }

        ITrainer Trainer { get; set; }

        IList<ILectureResource> Resources { get; }
    }
}
