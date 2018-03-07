using System.Collections.Generic;
using Academy.Models.Contracts;

namespace Academy.Core.Contracts
{
    public interface IEngine
    {
        IReader Reader { get; set; }

        IWriter Writer { get; set; }

        IParser Parser { get; set; }

        IList<ISeason> Seasons { get;  }

        IList<IStudent> Students { get; }

        IList<ITrainer> Trainers { get; }

        void Start();
    }
}
