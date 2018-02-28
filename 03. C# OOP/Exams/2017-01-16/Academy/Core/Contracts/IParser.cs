namespace Academy.Core.Contracts
{
    using System.Collections.Generic;
    using Academy.Commands.Contracts;

    public interface IParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
