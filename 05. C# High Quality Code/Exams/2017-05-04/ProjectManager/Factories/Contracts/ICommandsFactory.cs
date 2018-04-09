using ProjectManager.Commands.Contracts;

namespace ProjectManager.Factories.Contracts
{
    /// <summary>
    /// Represents the commandsFactory of the ProjectManager application.
    /// </summary>
    public interface ICommandsFactory
    {
        /// <summary>
        /// Creates the command from the passed command string.
        /// </summary>
        /// <param name="commandName">Represents the command name.</param>
        /// <returns>Returns an instance of Command.</returns>
        ICommand CreateCommandFromString(string commandName);

        /// <summary>
        /// Represents the create project command.
        /// </summary>
        /// <returns>Returns an instance of CreateProjectCommand.</returns>
        ICommand CreateProjectCommand();

        /// <summary>
        /// Represents the create user command.
        /// </summary>
        /// <returns>Returns an instance of CreateUserCommand.</returns>
        ICommand CreateUserCommand();

        /// <summary>
        /// Represents the create task command.
        /// </summary>
        /// <returns>Returns an instance of CreateTaskCommand.</returns>
        ICommand CreateTaskCommand();

        /// <summary>
        /// Represents the list projects command.
        /// </summary>
        /// <returns>Returns an instance of ListProjectsCommand.</returns>
        ICommand ListProjects();

        /// <summary>
        /// Represents the list project details command.
        /// </summary>
        /// <returns>Returns an instance of ListProjectDetailsCommand.</returns>
        ICommand ListProjectDetails();
    }
}
