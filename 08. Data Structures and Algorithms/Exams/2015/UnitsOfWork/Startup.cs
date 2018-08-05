using System;
using System.Text;

using UnitsOfWork.Common;
using UnitsOfWork.Core;

namespace UnitsOfWork
{
    public class Startup
    {
        public static void Main()
        {
            var stringBuilder = new StringBuilder();
            var stringWriter = new StringWriter(stringBuilder);

            var engine = new Engine(stringWriter);
            engine.Start();

            var result = stringBuilder.ToString().TrimEnd();

            Console.WriteLine(result);
        }
    }
}
