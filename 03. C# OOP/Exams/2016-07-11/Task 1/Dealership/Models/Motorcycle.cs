using System;
using System.Text;
using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Motorcycle : Vehicle, IMotorcycle
    {
        private string category;

        public Motorcycle(string make, string model, decimal price, string category)
            : base(make, model, price)
        {
            this.Wheels = 2;
            this.Type = VehicleType.Motorcycle;
            this.Category = category;
        }

        public string Category
        {
            get
            {
                return this.category;
            }

            private set
            {
                Validator.ValidateNull(value, Constants.VehicleCannotBeNull);

                this.ValidateCategoryRange(value, Constants.MinCategoryLength, Constants.MaxCategoryLength, string.Format(Constants.StringMustBeBetweenMinAndMax, "Category", Constants.MinCategoryLength, Constants.MaxCategoryLength));

                this.category = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("  Category: {0}", this.Category);
            sb.Append(Environment.NewLine);
            sb.AppendLine(this.PrintComments());

            return base.ToString() + sb.ToString();
        }

        private void ValidateCategoryRange(string value, int min, int max, string message)
        {
            if (value.Length < min || value.Length > max)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
