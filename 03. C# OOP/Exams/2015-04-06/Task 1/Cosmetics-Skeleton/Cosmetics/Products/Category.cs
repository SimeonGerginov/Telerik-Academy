using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Category : ICategory
    {
        private string name;
        private ICollection<IProduct> products;

        public Category(string name)
        {
            this.Name = name;
            this.Products = new List<IProduct>();
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
                Validator.CheckIfStringLengthIsValid(value, GlobalErrorMessages.MaxCategoryNameLength, GlobalErrorMessages.MinCategoryNameLength, GlobalErrorMessages.CategoryNameError);

                this.name = value;
            }
        }

        public ICollection<IProduct> Products
        {
            get
            {
                this.products = this.products
                .OrderBy(p => p.Brand)
                .ThenByDescending(p => p.Price)
                .ToList();

                return this.products;
            }

            private set
            {
                this.products = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            if (cosmetics == null)
            {
                throw new ArgumentNullException(string.Join(GlobalErrorMessages.ObjectCannotBeNull, cosmetics.Name));
            }

            this.products.Add(cosmetics);
        }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();

            if (this.Products.Count == 1)
            {
                sb.AppendFormat("{0} category – {1} product in total", this.Name, this.Products.Count);
            }
            else
            {
                sb.AppendFormat("{0} category – {1} products in total", this.Name, this.Products.Count);
            }

            sb.Append(Environment.NewLine);
            foreach (var product in this.products)
            {
                sb.Append(product.Print());
            }

            return sb.ToString().TrimEnd();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (!this.Products.Contains(cosmetics))
            {
                string message = string.Join("Product {0} does not exist in category {1}!", cosmetics, this.Name);
                throw new InvalidOperationException(message);
            }

            this.products.Remove(cosmetics);
        }
    }
}
