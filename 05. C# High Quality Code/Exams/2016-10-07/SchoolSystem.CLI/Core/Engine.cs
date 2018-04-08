using System;
using System.Collections.Generic;

using SchoolSystem.CLI.Constants;
using SchoolSystem.CLI.Core.Contracts;
using SchoolSystem.CLI.Models.Contracts;

namespace SchoolSystem.CLI.Core
{
    public class Engine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IParser parser;

        public Engine(IReader reader, IWriter writer, IParser parser)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(GlobalConstants.ReaderNullErrorMessage);
            }

            if (writer == null)
            {
                throw new ArgumentNullException(GlobalConstants.WriterNullErrorMessage);
            }

            if (parser == null)
            {
                throw new ArgumentNullException(GlobalConstants.ParserNullErrorMessage);
            }

            this.reader = reader;
            this.writer = writer;
            this.parser = parser;

            Teachers = new Dictionary<int, ITeacher>();
            Students = new Dictionary<int, IStudent>();
        }

        public static IDictionary<int, ITeacher> Teachers { get; set; }

        public static IDictionary<int, IStudent> Students { get; set; }

        public void Start()
        {
            while (true)
            {
                try
                {
                    string commandAsString = this.reader.ReadLine();

                    if (commandAsString == GlobalConstants.TerminationCommand)
                    {
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrEmpty(commandAsString))
            {
                throw new ArgumentNullException(GlobalConstants.CommandNullErrorMessage);
            }

            ICommand command = this.parser.ParseCommand(commandAsString);
            IList<string> parameters = this.parser.ParseParameters(commandAsString);

            string executionResults = command.Execute(parameters);
            this.writer.WriteLine(executionResults);
        }
    }
}
