using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class Goblin : Creature
    {
        private const int attack = 4;
        private const int defense = 2;
        private const int healthPoints = 5;
        private const decimal damage = 1.5M;

        public Goblin() 
            : base(attack, defense, healthPoints, damage)
        {
        }
    }
}
