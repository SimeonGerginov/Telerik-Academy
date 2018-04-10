using System;
using System.Text;

using ProjectManager.Common.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Providers;
using ProjectManager.Core.Contracts;

namespace ProjectManager.Core
{
    public class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly ICommandProcessor processor;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(ILogger logger, ICommandProcessor processor, IReader reader, IWriter writer)
        {
            this.logger = logger ?? FileLogger.Instance;
            this.processor = processor ?? CommandProcessor.Instance;
            this.reader = reader ?? ConsoleReader.Instance;
            this.writer = writer ?? ConsoleWriter.Instance;
        }

        public void Start()
        {
            StringBuilder sb = new StringBuilder();

            for (;;)
            {
                string commandAsString = this.reader.ReadLine();

                if (commandAsString.ToLower() == "exit")
                {
                    this.writer.Write(sb.ToString());
                    this.writer.WriteLine("Program terminated.");
                    break;
                }

                try
                {
                    string executionResult = this.processor.Process(commandAsString);
                    sb.AppendLine(executionResult);
                }
                catch (UserValidationException ex)
                {
                    sb.AppendLine(ex.Message);
                }
                catch (Exception ex)
                {
                    sb.AppendLine("Something happened!");
                    this.logger.Error(ex.Message);
                }
            }
        }
    }
}
