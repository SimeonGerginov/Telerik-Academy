namespace Academy.Models.Utils.Contracts
{
    using Academy.Models.Contracts;
    using Academy.Models.Enums;

    public interface ICourseResult
    {
        ICourse Course { get; }

        float ExamPoints { get; }

        float CoursePoints { get; }

        Grade Grade { get; }
    }
}
