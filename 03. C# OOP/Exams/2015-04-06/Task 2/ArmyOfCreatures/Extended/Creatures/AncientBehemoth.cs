using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class AncientBehemoth : Creature
    {
        private const int AttackPoints = 19;
        private const int DefensePoints = 19;
        private const int HealthPointsValue = 300;
        private const decimal DamageValue = 40;
        private const decimal Percentage = 80;
        private const int Rounds = 5;

        public AncientBehemoth() 
            : base(AttackPoints, DefensePoints, HealthPointsValue, DamageValue)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(Percentage));
            this.AddSpecialty(new DoubleDefenseWhenDefending(Rounds));
        }
    }
}
