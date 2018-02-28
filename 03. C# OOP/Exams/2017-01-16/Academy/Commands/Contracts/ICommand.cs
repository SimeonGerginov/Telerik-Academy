namespace Academy.Commands.Contracts
{
    using System.Collections.Generic;

    public interface ICommand
    {
        /// <summary>
        /// Executes the command with the passed parameters.
        /// </summary>
        /// <param name="parameters">Parameters to execute the command with.</param>
        /// <returns>Returns execution result message.</returns>
        string Execute(IList<string> parameters);
    }
}
