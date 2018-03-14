using ArmyOfCreatures.Extended.Specialties;
using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class CyclopsKing : Creature
    {
        private const int AttackPoints = 17;
        private const int DefensePoints = 13;
        private const int HealthPointsValue = 70;
        private const decimal DamageValue = 18;
        private const int AttackToAdd = 3;
        private const int DoubleAttackRounds = 4;
        private const int DoubleDamageRounds = 1;

        public CyclopsKing() 
            : base(AttackPoints, DefensePoints, HealthPointsValue, DamageValue)
        {
            this.AddSpecialty(new AddAttackWhenSkip(AttackToAdd));
            this.AddSpecialty(new DoubleAttackWhenAttacking(DoubleAttackRounds));
            this.AddSpecialty(new DoubleDamage(DoubleDamageRounds));
        }
    }
}
