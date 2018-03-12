using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class DominicRendeto : Driver
    {
        private const string DominicRendetoDriverName = "Dominic Rendeto";

        public DominicRendeto() 
            : base(DominicRendetoDriverName, GenderType.Male)
        {
        }
    }
}
