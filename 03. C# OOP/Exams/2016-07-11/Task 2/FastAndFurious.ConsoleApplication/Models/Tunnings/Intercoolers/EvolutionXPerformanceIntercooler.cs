using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers
{
    public class EvolutionXPerformanceIntercooler : Intercooler
    {
        private const int EvolutionXPerformanceIntercoolerWeightInGrams = 4500;
        private const int EvolutionXPerformanceIntercoolerAccelerationBonus = -5;
        private const int EvolutionXPerformanceIntercoolerTopSpeedBonus = 40;
        private const decimal EvolutionXPerformanceIntercoolerPriceInUSADollars = 499;

        public EvolutionXPerformanceIntercooler()
            : base(
                  EvolutionXPerformanceIntercoolerPriceInUSADollars,
                  EvolutionXPerformanceIntercoolerWeightInGrams,
                  EvolutionXPerformanceIntercoolerAccelerationBonus,
                  EvolutionXPerformanceIntercoolerTopSpeedBonus,
                  TunningGradeType.HighGrade,
                  IntercoolerType.AirToLiquidIntercooler)
        {
        }
    }
}
