using SchoolSystem.CLI.Enums;

namespace SchoolSystem.CLI.Models.Contracts
{
    public interface ITeacher
    {
        Subject Subject { get; set; }

        void AddMark(IStudent student, float value);
    }
}
