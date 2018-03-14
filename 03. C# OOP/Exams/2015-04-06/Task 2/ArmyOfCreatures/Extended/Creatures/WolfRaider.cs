using ArmyOfCreatures.Extended.Specialties;
using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class WolfRaider : Creature
    {
        private const int AttackPoints = 8;
        private const int DefensePoints = 5;
        private const int HealthPointsValue = 10;
        private const decimal DamageValue = 3.5M;
        private const int Rounds = 7;

        public WolfRaider() 
            : base(AttackPoints, DefensePoints, HealthPointsValue, DamageValue)
        {
            this.AddSpecialty(new DoubleDamage(Rounds));
        }
    }
}
