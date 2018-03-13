namespace Cosmetics.Common
{
    public class GlobalErrorMessages
    {
        public const string StringCannotBeNullOrEmpty = "{0} cannot be null or empty!";
        public const string ObjectCannotBeNull = "{0} cannot be null!";
        public const string InvalidStringLength = "{0} must be between {1} and {2} symbols long!";

        public const string CategoryNameError = "Category name must be between 2 and 15 symbols long!";
        public const int MinCategoryNameLength = 2;
        public const int MaxCategoryNameLength = 15;

        public const string ProductNameError = "Product name must be between 3 and 10 symbols long!";
        public const int MinProductNameLength = 3;
        public const int MaxProductNameLength = 10;

        public const string ProductBrandError = "Product brand must be between 2 and 10 symbols long!";
        public const int MinProductBrandLength = 2;
        public const int MaxProductBrandLength = 10;

        public const string IngredientNameError = "Each ingredient must be between 4 and 12 symbols long!";
        public const int MinIngredientNameLength = 4;
        public const int MaxIngredientNameLength = 12;
    }
}
