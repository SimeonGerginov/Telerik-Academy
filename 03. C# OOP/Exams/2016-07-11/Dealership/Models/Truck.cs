using Dealership.Common;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Truck : ITruck
    {
        private const string WeightCapacityError = "Weight Capacity cannot be null!";

        private int weightCapacity;

        public Truck(int weightCapacity)
        {
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
                Validator.ValidateIntRange(value, Constants.MinCapacity, Constants.MaxCapacity,
                    Constants.NumberMustBeBetweenMinAndMax);

                this.weightCapacity = value;
            }
        }
    }
}
