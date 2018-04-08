namespace SchoolSystem.CLI.Core.Contracts
{
    /// <summary>
    /// Interface for a source Writer provider
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Writes data to a given source and appends new line at the end.
        /// </summary>
        /// <param name="message">The data to be written.</param>
        void WriteLine(string message);
    }
}
