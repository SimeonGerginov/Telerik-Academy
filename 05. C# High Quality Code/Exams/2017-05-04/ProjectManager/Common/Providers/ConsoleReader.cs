using System;
using ProjectManager.Common.Contracts;

namespace ProjectManager.Common.Providers
{
    public class ConsoleReader : IReader
    {
        private static IReader instance;

        private ConsoleReader()
        {
        }

        public static IReader Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConsoleReader();
                }

                return instance;
            }
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
