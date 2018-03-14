using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class AncientBehemoth : Creature
    {
        private const int attack = 19;
        private const int defense = 19;
        private const int healthPoints = 300;
        private const decimal damage = 40;
        private const decimal percentage = 80;
        private const int rounds = 5;

        public AncientBehemoth() 
            : base(attack, defense, healthPoints, damage)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(percentage));
            this.AddSpecialty(new DoubleDefenseWhenDefending(rounds));
        }
    }
}
