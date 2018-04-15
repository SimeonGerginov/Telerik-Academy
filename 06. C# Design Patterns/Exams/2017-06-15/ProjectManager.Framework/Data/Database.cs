using System.Collections.Generic;

using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Models;

namespace ProjectManager.Data
{
    public class Database : IDatabase
    {
        private IList<Project> projects;

        public Database()
        {
            this.projects = new List<Project>();
        }

        public IList<Project> Projects
        {
            get
            {
                return this.projects;
            }
        }
    }
}
