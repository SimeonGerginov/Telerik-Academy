namespace Academy.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Academy.Core.Contracts;
    using Academy.Core.Providers;
    using Academy.Models.Contracts;

    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        private static IEngine instanceHolder = new Engine();
      
        private readonly StringBuilder builder = new StringBuilder();

        // private because of Singleton design pattern
        private Engine()
        {
            this.Reader = new ConsoleReader();
            this.Writer = new ConsoleWriter();
            this.Parser = new CommandParser();

            this.Seasons = new List<ISeason>();
            this.Students = new List<IStudent>();
            this.Trainers = new List<ITrainer>();
        }

        public static IEngine Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        // Property dependencty injection not validated for simplicity
        public IReader Reader { get; set; }

        public IWriter Writer { get; set; }

        public IParser Parser { get; set; }

        public IList<ISeason> Seasons { get; private set; }

        public IList<IStudent> Students { get; private set; }

        public IList<ITrainer> Trainers { get; private set; }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.Reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        this.Writer.Write(this.builder.ToString());
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (ArgumentOutOfRangeException)
                {
                    this.builder.AppendLine("Invalid command parameters supplied or the entity with that ID for does not exist.");
                }
                catch (Exception ex)
                {
                    this.builder.AppendLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.Parser.ParseCommand(commandAsString);
            var parameters = this.Parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.builder.AppendLine(executionResult);
        }
    }
}
