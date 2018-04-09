using System.Collections.Generic;
using ProjectManager.Models.Contracts;

namespace ProjectManager.Data
{
    // You are not allowed to modify this interface (except to add documentation)
    public interface IDatabase
    {
        IList<IProject> Projects { get; }
    }
}
