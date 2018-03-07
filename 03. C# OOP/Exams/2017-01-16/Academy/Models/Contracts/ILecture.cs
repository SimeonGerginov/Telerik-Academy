using System;
using System.Collections.Generic;

namespace Academy.Models.Contracts
{
    public interface ILecture
    {
        string Name { get; }

        DateTime Date { get; }

        ITrainer Trainer { get; }

        IList<ILectureResource> Resources { get; }
    }
}
