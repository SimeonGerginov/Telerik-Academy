using System;
using UnitsOfWork.Common;

namespace UnitsOfWork.Models
{
    public class Unit : IComparable<Unit>
    {
        private string name;
        private string type;
        private int attack;

        public Unit(string name, string type, int attack)
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (value.Length < Constants.UnitNameMinLength || value.Length > Constants.UnitNameMaxLength)
                {
                    throw new ArgumentOutOfRangeException(String.Format(Constants.UnitNameError, Constants.UnitNameMinLength, Constants.UnitNameMaxLength));
                }

                this.name = value;
            }
        }

        public string Type
        {
            get => this.type;

            private set
            {
                if (value.Length < Constants.UnitTypeMinLength || value.Length > Constants.UnitTypeMaxLength)
                {
                    throw new ArgumentOutOfRangeException(String.Format(Constants.UnitTypeError, Constants.UnitTypeMinLength, Constants.UnitTypeMaxLength));
                }

                this.type = value;
            }
        }

        public int Attack
        {
            get => this.attack;

            private set
            {
                if (value < Constants.UnitMinAttack || value > Constants.UnitMaxAttack)
                {
                    throw new ArgumentOutOfRangeException(String.Format(Constants.UnitAttackError, Constants.UnitMinAttack, Constants.UnitMaxAttack));
                }

                this.attack = value;
            }
        }

        public int CompareTo(Unit other)
        {
            if (this.Attack == other.Attack)
            {
                return this.Name.CompareTo(other.Name);
            }

            return other.Attack.CompareTo(this.Attack);
        }

        public override string ToString()
        {
            return $"{this.Name}[{this.Type}]({this.Attack})";
        }
    }
}
