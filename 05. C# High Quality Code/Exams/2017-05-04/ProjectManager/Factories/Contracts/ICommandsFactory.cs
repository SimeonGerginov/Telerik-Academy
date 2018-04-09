using ProjectManager.Commands.Contracts;

namespace ProjectManager.Factories.Contracts
{
    public interface ICommandsFactory
    {
        ICommand CreateCommandFromString(string commandName);

        ICommand CreateProjectCommand();

        ICommand CreateUserCommand();

        ICommand CreateTaskCommand();
    }
}
