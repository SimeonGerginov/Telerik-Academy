namespace Academy.Core.Providers
{
    using System;
    using Academy.Core.Contracts;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
