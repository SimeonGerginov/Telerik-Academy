using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers
{
    public class ViperGenieIntercooler : Intercooler
    {
        private const int ViperGenieIntercoolerWeightInGrams = 5300;
        private const int ViperGenieIntercoolerAccelerationBonus = 0;
        private const int ViperGenieIntercoolerTopSpeedBonus = 25;
        private const decimal ViperGenieIntercoolerPriceInUSADollars = 289;

        public ViperGenieIntercooler()
            : base(
                  ViperGenieIntercoolerPriceInUSADollars,
                  ViperGenieIntercoolerWeightInGrams,
                  ViperGenieIntercoolerAccelerationBonus,
                  ViperGenieIntercoolerTopSpeedBonus,
                  TunningGradeType.MidGrade,
                  IntercoolerType.ChargeAirIntercooler)
        {
        }
    }
}
