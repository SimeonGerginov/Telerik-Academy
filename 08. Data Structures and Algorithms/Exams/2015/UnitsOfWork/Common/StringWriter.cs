using System.Text;
using UnitsOfWork.Contracts;

namespace UnitsOfWork.Common
{
    public class StringWriter : IWriter
    {
        private readonly StringBuilder stringBuilder;

        public StringWriter(StringBuilder stringBuilder)
        {
            this.stringBuilder = stringBuilder;
        }

        public void AppendLine(string line)
        {
            this.stringBuilder.AppendLine(line);
        }
    }
}
