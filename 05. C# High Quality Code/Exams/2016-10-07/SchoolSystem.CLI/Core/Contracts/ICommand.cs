using System.Collections.Generic;

namespace SchoolSystem.CLI.Core.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
