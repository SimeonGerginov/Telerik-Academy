using System.Collections.Generic;

namespace SchoolSystem.CLI.Core.Contracts
{
    public interface IParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
