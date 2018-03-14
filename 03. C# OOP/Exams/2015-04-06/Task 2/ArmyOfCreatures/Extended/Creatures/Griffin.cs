using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class Griffin : Creature
    {
        private const int AttackPoints = 8;
        private const int DefensePoints = 8;
        private const int HealthPointsValue = 25;
        private const decimal DamageValue = 4.5M;
        private const int Rounds = 5;
        private const int DefensePointsForSpecialty = 3;

        public Griffin() 
            : base(AttackPoints, DefensePoints, HealthPointsValue, DamageValue)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(Rounds));
            this.AddSpecialty(new AddDefenseWhenSkip(DefensePointsForSpecialty));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
