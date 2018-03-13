using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems
{
    public class BorlaExhaust : Exhaust
    {
        private const int BorlaExhaustWeightInGrams = 14600;
        private const int BorlaExhaustAccelerationBonus = 12;
        private const int BorlaExhaustTopSpeedBonus = 40;
        private const decimal BorlaExhaustPriceInUSADollars = 1299;

        public BorlaExhaust()
            : base(
                  BorlaExhaustPriceInUSADollars,
                  BorlaExhaustWeightInGrams,
                  BorlaExhaustAccelerationBonus,
                  BorlaExhaustTopSpeedBonus,
                  TunningGradeType.HighGrade,
                  ExhaustType.CeramicCoated)
        {
        }
    }
}
