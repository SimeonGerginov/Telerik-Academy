using Dealership.Common;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Priceable : IPriceable
    {
        private const string PriceError = "Price cannot be null!";

        private decimal price;

        public Priceable(decimal price)
        {
            this.Price = price;
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
    }
}
