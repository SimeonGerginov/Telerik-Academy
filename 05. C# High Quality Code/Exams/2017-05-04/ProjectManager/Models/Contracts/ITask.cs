using ProjectManager.Enums;

namespace ProjectManager.Models.Contracts
{
    public interface ITask
    {
        string Name { get; set; }

        IUser Owner { get; set; }

        TaskState State { get; set; }
    }
}
