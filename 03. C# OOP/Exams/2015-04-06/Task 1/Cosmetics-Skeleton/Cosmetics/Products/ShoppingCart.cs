using System;
using System.Collections.Generic;

using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class ShoppingCart : IShoppingCart
    {
        private ICollection<IProduct> products;

        public ShoppingCart()
        {
            this.Products = new List<IProduct>();
        }

        public ICollection<IProduct> Products
        {
            get
            {
                return this.products;
            }

            private set
            {
                this.products = value;
            }
        }

        public void AddProduct(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(string.Join(GlobalErrorMessages.ObjectCannotBeNull, product.Name));
            }

            this.products.Add(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.Products.Contains(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.products.Remove(product);
        }

        public decimal TotalPrice()
        {
            decimal totalPrice = 0;

            foreach (var product in this.Products)
            {
                totalPrice += product.Price;
            }

            return totalPrice;
        }
    }
}
