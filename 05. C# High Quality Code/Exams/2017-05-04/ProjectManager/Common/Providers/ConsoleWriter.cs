using System;
using ProjectManager.Common.Contracts;

namespace ProjectManager.Common.Providers
{
    public class ConsoleWriter : IWriter
    {
        private static IWriter instance;

        private ConsoleWriter()
        {
        }

        public static IWriter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConsoleWriter();
                }

                return instance;
            }
        }

        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
