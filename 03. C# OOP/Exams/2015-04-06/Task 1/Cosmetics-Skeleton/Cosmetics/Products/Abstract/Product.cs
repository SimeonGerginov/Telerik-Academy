using System;
using System.Text;

using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products.Abstract
{
    public abstract class Product : IProduct
    {
        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Name"));
                Validator.CheckIfStringLengthIsValid(value, GlobalErrorMessages.MaxProductNameLength, GlobalErrorMessages.MinProductNameLength, GlobalErrorMessages.ProductNameError);

                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Brand"));
                Validator.CheckIfStringLengthIsValid(value, GlobalErrorMessages.MaxProductBrandLength, GlobalErrorMessages.MinProductBrandLength, GlobalErrorMessages.ProductBrandError);

                this.brand = value;
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
                this.price = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }

            private set
            {
                this.gender = value;
            }
        }

        public virtual string Print()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("- {0} – {1}:", this.Brand, this.Name);
            sb.Append(Environment.NewLine);
            sb.AppendFormat("  * Price: ${0}", this.Price);
            sb.Append(Environment.NewLine);
            sb.AppendFormat("  * For gender: {0}", this.Gender.ToString());
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}
