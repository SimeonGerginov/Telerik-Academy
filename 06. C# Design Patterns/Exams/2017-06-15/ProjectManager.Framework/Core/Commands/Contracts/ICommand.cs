using System.Collections.Generic;

namespace ProjectManager.Framework.Core.Commands.Contracts
{
    public interface ICommand
    {
        int ParameterCount { get; }

        string Execute(IList<string> parameters);
    }
}
