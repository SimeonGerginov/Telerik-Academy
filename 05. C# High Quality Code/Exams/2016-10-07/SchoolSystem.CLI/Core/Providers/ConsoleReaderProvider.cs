using System;
using SchoolSystem.CLI.Core.Contracts;

namespace SchoolSystem.CLI.Core.Providers
{
    public class ConsoleReaderProvider : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
