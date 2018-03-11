using System;
using System.Collections.Generic;
using System.Text;
using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Car : Vehicle, ICar
    {
        private const string SeatsError = "Seats cannot be null!";

        private int seats;

        public Car(string make, string model, decimal price, int seats)
            : base(make, model, price)
        {
            this.Wheels = 4;
            this.Type = VehicleType.Car;
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

                Validator.ValidateIntRange(value, Constants.MinSeats, Constants.MaxSeats, string.Format(Constants.NumberMustBeBetweenMinAndMax, "Seats", Constants.MinSeats, Constants.MaxSeats));

                this.seats = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("  Seats: {0}", this.Seats);
            sb.Append(Environment.NewLine);
            sb.AppendLine(this.PrintComments());

            return base.ToString() + sb.ToString();
        }
    }
}
