using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems
{
    public class MagnaflowExhaust : Exhaust
    {
        private const int MagnaflowExhaustWeightInGrams = 12800;
        private const int MagnaflowExhaustAccelerationBonus = 5;
        private const int MagnaflowExhaustTopSpeedBonus = 25;
        private const decimal MagnaflowExhaustPriceInUSADollars = 379;

        public MagnaflowExhaust()
            : base(
                  MagnaflowExhaustPriceInUSADollars,
                  MagnaflowExhaustWeightInGrams,
                  MagnaflowExhaustAccelerationBonus,
                  MagnaflowExhaustTopSpeedBonus,
                  TunningGradeType.LowGrade,
                  ExhaustType.NickelChromePlated)
        {
        }
    }
}
