using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystem
{
    public class RemusExhaust : Exhaust
    {
        private const int RemusExhaustWeightInGrams = 11500;
        private const int RemusExhaustAccelerationBonus = 8;
        private const int RemusExhaustTopSpeedBonus = 32;
        private const decimal RemusExhaustPriceInUSADollars = 679;

        public RemusExhaust()
            : base(
                  RemusExhaustPriceInUSADollars,
                  RemusExhaustWeightInGrams,
                  RemusExhaustAccelerationBonus,
                  RemusExhaustTopSpeedBonus,
                  TunningGradeType.MidGrade,
                  ExhaustType.StainlessSteel)
        {
        }
    }
}
