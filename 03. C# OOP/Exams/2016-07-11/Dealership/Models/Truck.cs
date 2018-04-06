using System;
using System.Text;

using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Truck : Vehicle, ITruck
    {
        private const string WeightCapacityError = "Weight Capacity cannot be null!";

        private int weightCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity)
            : base(make, model, price)
        {
            this.Wheels = 8;
            this.Type = VehicleType.Truck;
            this.WeightCapacity = weightCapacity;
        }

        public int WeightCapacity
        {
            get
            {
                return this.weightCapacity;
            }

            private set
            {
                Validator.ValidateNull(value, WeightCapacityError);

                Validator.ValidateIntRange(value, Constants.MinCapacity, Constants.MaxCapacity, string.Format(Constants.NumberMustBeBetweenMinAndMax, "Weight capacity", Constants.MinCapacity, Constants.MaxCapacity));

                this.weightCapacity = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("  Weight Capacity: {0}t", this.WeightCapacity);
            sb.Append(Environment.NewLine);
            sb.AppendLine(this.PrintComments());

            return base.ToString() + sb.ToString();
        }
    }
}
