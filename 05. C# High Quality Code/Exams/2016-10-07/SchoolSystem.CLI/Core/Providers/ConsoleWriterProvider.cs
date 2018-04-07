using System;
using SchoolSystem.CLI.Core.Contracts;

namespace SchoolSystem.CLI.Core.Providers
{
    public class ConsoleWriterProvider : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
