using System.Collections.Generic;
using Academy.Commands.Contracts;

namespace Academy.Core.Contracts
{
    public interface IParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
