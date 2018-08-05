using System;

namespace UnitsOfWork
{
    public class Startup
    {
        public static void Main()
        {
            var engine = new Engine();
            var result = engine.Start();

            Console.WriteLine(result);
        }
    }
}
