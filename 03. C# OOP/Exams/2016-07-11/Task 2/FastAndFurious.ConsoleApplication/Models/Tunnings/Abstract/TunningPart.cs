using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Common;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Abstract
{
    public abstract class TunningPart : IdentifiableObject, ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable
    {
        private readonly decimal price;
        private readonly int weight;
        private readonly int acceleration;
        private readonly int topSpeed;
        private readonly TunningGradeType gradeType;

        public TunningPart(
            decimal price,
            int weight,
            int acceleration,
            int topSpeed,
            TunningGradeType gradeType)
            : base()
        {
            this.price = price;
            this.weight = weight;
            this.acceleration = acceleration;
            this.topSpeed = topSpeed;
            this.gradeType = gradeType;
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
        }

        public int Weight
        {
            get
            {
                return this.weight;
            }
        }

        public int Acceleration
        {
            get
            {
                return this.acceleration;
            }
        }

        public int TopSpeed
        {
            get
            {
                return this.topSpeed;
            }
        }

        public TunningGradeType GradeType
        {
            get
            {
                return this.gradeType;
            }
        }
    }
}
