namespace SchoolSystem.CLI.Constants
{
    public static class GlobalConstants
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 31;

        public const float MinValue = 2;
        public const float MaxValue = 6;

        public const string NameErrorMessage = "Name must be between 2 and 31 symbols long!";
        public const string NameCharactersErrorMessage = "Name must contaion only latin letters!";
        public const string NullErrorMessage = "Value cannot be null!";
        public const string ValueErrorMessage = "Value must be between 2 and 6!";
    }
}
