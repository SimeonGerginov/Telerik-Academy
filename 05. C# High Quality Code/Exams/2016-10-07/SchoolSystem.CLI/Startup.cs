using SchoolSystem.CLI.Core;
using SchoolSystem.CLI.Core.Contracts;
using SchoolSystem.CLI.Core.Providers;

namespace SchoolSystem.CLI
{
    public class Startup
    {
        public static void Main()
        {
            IReader reader = new ConsoleReaderProvider();
            IWriter writer = new ConsoleWriterProvider();
            IParser parser = new CommandParserProvider();

            Engine engine = new Engine(reader, writer, parser);
            engine.Start();
        }
    }
}
