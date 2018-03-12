using System;
using System.Collections.Generic;
using System.Linq;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Exceptions;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Common;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract
{
    public abstract class MotorVehicle : IdentifiableObject, IMotorVehicle, IWeightable, IValuable
    {
        private readonly decimal price;
        private readonly int weight;
        private readonly int topSpeed;
        private readonly int acceleration;
        private readonly ICollection<ITunningPart> tunningParts;

        public MotorVehicle(
            decimal price,
            int weight,
            int topSpeed,
            int acceleration)
            : base()
        {
            this.price = price;
            this.weight = weight;
            this.acceleration = acceleration;
            this.topSpeed = topSpeed;
            this.tunningParts = new List<ITunningPart>();
        }

        public decimal Price
        {
            get
            {
                return this.Price + this.TunningParts.Sum(x => x.Price);
            }
        }
        public int Weight
        {
            get
            {
                return this.Weight + this.TunningParts.Sum(x => x.Weight);
            }
        }
        public int Acceleration
        {
            get
            {
                return this.Acceleration + this.TunningParts.Sum(x => x.Acceleration);
            }
        }
        public int TopSpeed
        {
            get
            {
                return this.TopSpeed + this.TunningParts.Sum(x => x.TopSpeed);
            }
        }
        public IEnumerable<ITunningPart> TunningParts
        {
            get
            {
                return this.tunningParts;
            }
        }

        public void AddTunning(ITunningPart part)
        {
            if (this.TunningParts.Any(tp => tp.GetType().BaseType == part.GetType().BaseType))
            {
                string message = GlobalConstants.CannotAddMultiplePartsOfTheSameTypeToVehicleExceptionMessage;
                string parameter = part.GetType().Name;

                throw new TunningDuplicationException(message, parameter);
            }
        }

        public bool RemoveTunning(ITunningPart part)
        {
            return this.tunningParts.Remove(part);
        }

        public TimeSpan Race(int trackLengthInMeters)
        {
            // Oohh boy, you shouldn't have missed the PHYSICS class in high school.
            throw new NotImplementedException();
        }
    }
}
