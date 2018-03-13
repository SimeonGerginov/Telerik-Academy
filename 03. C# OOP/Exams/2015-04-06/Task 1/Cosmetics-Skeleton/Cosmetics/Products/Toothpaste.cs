using System.Collections.Generic;
using System.Text;

using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Products.Abstract;

namespace Cosmetics.Products
{
    public class Toothpaste : Product, IToothpaste
    {
        private string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients) 
            : base(name, brand, price, gender)
        {
            this.ValidateIngredients(ingredients);
            this.Ingredients = string.Join(", ", ingredients);
        }

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }

            private set
            {
                this.ingredients = value;
            }
        }

        public override string Print()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("  * Ingredients: {0}", this.Ingredients);

            return base.Print() + sb.ToString();
        }

        private void ValidateIngredients(IList<string> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                Validator.CheckIfStringIsNullOrEmpty(ingredient, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Ingredient Name"));
                Validator.CheckIfStringLengthIsValid(ingredient, GlobalErrorMessages.MaxIngredientNameLength, GlobalErrorMessages.MinIngredientNameLength, GlobalErrorMessages.IngredientNameError);
            }
        }
    }
}
