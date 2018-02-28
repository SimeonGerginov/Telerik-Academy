namespace Academy.Models.Contracts
{
    using System.Collections.Generic;

    using Academy.Models.Enums;
    using Academy.Models.Utils.Contracts;

    public interface IStudent : IUser
    {
        Track Track { get; set; }

        IList<ICourseResult> CourseResults { get; set; }
    }
}
