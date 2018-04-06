using ArmyOfCreatures.Logic;

namespace ArmyOfCreatures.Console
{
    using System;

    public class ConsoleLogger : ILogger
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
