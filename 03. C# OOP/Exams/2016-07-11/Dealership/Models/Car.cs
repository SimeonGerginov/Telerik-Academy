using Dealership.Common;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Car : ICar
    {
        private const string SeatsError = "Seats cannot be null!";

        private int seats;

        public Car(int seats)
        {
            this.Seats = seats;
        }

        public int Seats
        {
            get
            {
                return this.seats;
            }

            private set
            {
                Validator.ValidateNull(value, SeatsError);
                Validator.ValidateIntRange(value, Constants.MinSeats, Constants.MaxSeats,
                    Constants.NumberMustBeBetweenMinAndMax);

                this.seats = value;
            }
        }
    }
}
