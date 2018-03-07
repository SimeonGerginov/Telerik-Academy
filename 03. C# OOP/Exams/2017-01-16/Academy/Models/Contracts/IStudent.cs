using System.Collections.Generic;

using Academy.Models.Enums;
using Academy.Models.Utils.Contracts;

namespace Academy.Models.Contracts
{
    public interface IStudent : IUser
    {
        Track Track { get; }

        IList<ICourseResult> CourseResults { get; set; }
    }
}
