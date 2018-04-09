using ProjectManager.Models.Contracts;

namespace ProjectManager.Factories.Contracts
{
    /// <summary>
    /// Represents the model factory which is responsible for creating users, tasks and projects.
    /// </summary>
    public interface IModelsFactory
    {
        /// <summary>
        /// Creates project with the given parameters.
        /// </summary>
        /// <param name="name">Represents the name of the project.</param>
        /// <param name="startingDate">Represents the starting date of the project.</param>
        /// <param name="endingDate">Represents the ending date of the project.</param>
        /// <param name="state">Represents the state of the project.</param>
        /// <returns>An Instance of the Project class.</returns>
        IProject CreateProject(string name, string startingDate, string endingDate, string state);

        /// <summary>
        /// Creates task with the given parameters.
        /// </summary>
        /// <param name="owner">Represents the owner of the task.</param>
        /// <param name="name">Represents the name of the task.</param>
        /// <param name="state">Represents the state of the task.</param>
        /// <returns>An instance of the Task class.</returns>
        ITask CreateTask(IUser owner, string name, string state);

        /// <summary>
        /// Creates user with the given parameters.
        /// </summary>
        /// <param name="username">Represents the username of the user.</param>
        /// <param name="email">Represents the email of the user.</param>
        /// <returns>An instance of the User class.</returns>
        IUser CreateUser(string username, string email);
    }
}
