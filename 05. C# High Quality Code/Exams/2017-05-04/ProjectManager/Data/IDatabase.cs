using System.Collections.Generic;
using ProjectManager.Models.Contracts;

namespace ProjectManager.Data
{
    /// <summary>
    /// Represents the database for the ProjectManager application.
    /// </summary>
    public interface IDatabase
    {
        IList<IProject> Projects { get; }
    }
}
