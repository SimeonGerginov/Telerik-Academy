using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class Goblin : Creature
    {
        private const int AttackPoints = 4;
        private const int DefensePoints = 2;
        private const int HealthPointsValue = 5;
        private const decimal DamageValue = 1.5M;

        public Goblin() 
            : base(AttackPoints, DefensePoints, HealthPointsValue, DamageValue)
        {
        }
    }
}
