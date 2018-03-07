using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle
    {
        private const string WheelsError = "Wheels cannot be null!";
        private const string MakeError = "Make cannot be null!";
        private const string ModelError = "Model cannot be null!";
        private const string PriceError = "Price cannot be null!";

        private int wheels;
        private VehicleType type;
        private string make;
        private string model;
        private IList<IComment> comments;
        private decimal price;

        public Vehicle(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Comments = new List<IComment>();
        }

        private void ValidateStringRange(string value, int min, int max, string message)
        {
            if (value.Length < min || value.Length > max)
            {
                throw new ArgumentException(message);
            }
        }

        protected string PrintComments()
        {
            StringBuilder sb = new StringBuilder();

            if (!this.Comments.Any())
            {
                sb.AppendLine("    --NO COMMENTS--");
                return sb.ToString();
            }

            int commentCount = 0;

            sb.AppendLine("    --COMMENTS--");
            sb.AppendLine("    ----------");

            foreach (var comment in this.Comments)
            {
                sb.Append(comment.ToString());
                if (commentCount < this.Comments.Count - 1)
                {
                    sb.AppendLine("    ----------");
                    sb.AppendLine("    ----------");
                }
                commentCount++;
            }

            sb.AppendLine("    ----------");
            sb.AppendLine("    --COMMENTS--");

            return sb.ToString();
        }

        public int Wheels
        {
            get
            {
                return this.wheels;
            }

            protected set
            {
                Validator.ValidateNull(value, WheelsError);

                Validator.ValidateIntRange(value, 
                    Constants.MinWheels, 
                    Constants.MaxWheels,
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, "Wheels",
                    Constants.MinWheels.ToString(),
                    Constants.MaxWheels.ToString()));

                this.wheels = value;
            }
        }

        public VehicleType Type
        {
            get
            {
                return this.type;
            }

            protected set
            {
                this.type = value;
            }
        }

        public string Make
        {
            get
            {
                return this.make;
            }

            private set
            {
                Validator.ValidateNull(value, MakeError);

                ValidateStringRange(value,
                    Constants.MinMakeLength,
                    Constants.MaxMakeLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax,
                    "Make",
                    Constants.MinMakeLength.ToString(),
                    Constants.MaxMakeLength.ToString()));

                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                Validator.ValidateNull(value, ModelError);

                ValidateStringRange(value,
                    Constants.MinModelLength,
                    Constants.MaxModelLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax,
                    "Model",
                    Constants.MinModelLength.ToString(),
                    Constants.MaxModelLength.ToString()));

                this.model = value;
            }
        }

        public IList<IComment> Comments
        {
            get
            {
                return this.comments;
            }

            private set
            {
                this.comments = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                Validator.ValidateNull(value, PriceError);

                Validator.ValidateDecimalRange(value, 
                    Constants.MinPrice, 
                    Constants.MaxPrice,
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, 
                    "Price", 
                    Constants.MinPrice, 
                    Constants.MaxPrice));

                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("  Make: {0}", this.Make);
            sb.Append(Environment.NewLine);
            sb.AppendFormat("  Model: {0}", this.Model);
            sb.Append(Environment.NewLine);
            sb.AppendFormat("  Wheels: {0}", this.Wheels);
            sb.Append(Environment.NewLine);
            sb.AppendFormat("  Price: ${0}", this.Price);
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}
