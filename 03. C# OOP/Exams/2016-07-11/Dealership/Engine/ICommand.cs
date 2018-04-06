using System.Collections.Generic;

namespace Dealership.Engine
{
    public interface ICommand
    {
        string Name { get; }

        List<string> Parameters { get; }
    }
}
