using System;
using System.Text;

using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Products.Abstract;

namespace Cosmetics.Products
{
    public class Shampoo : Product, IShampoo
    {
        private uint milliliters;
        private UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage) 
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
            this.Price *= this.Milliliters;
        }

        public uint Milliliters
        {
            get
            {
                return this.milliliters;
            }

            private set
            {
                this.milliliters = value;
            }
        }

        public UsageType Usage
        {
            get
            {
                return this.usage;
            }

            private set
            {
                this.usage = value;
            }
        }

        public override string Print()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("  * Quantity: {0} ml", this.Milliliters);
            sb.Append(Environment.NewLine);
            sb.AppendFormat("  * Usage: {0}", this.Usage);
            sb.Append(Environment.NewLine);

            return base.Print() + sb.ToString();
        }
    }
}
