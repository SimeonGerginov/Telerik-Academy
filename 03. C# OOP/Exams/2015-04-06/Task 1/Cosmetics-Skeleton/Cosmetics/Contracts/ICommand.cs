using System.Collections.Generic;

namespace Cosmetics.Contracts
{
    public interface ICommand
    {
        string Name { get; }

        IList<string> Parameters { get; }
    }
}
