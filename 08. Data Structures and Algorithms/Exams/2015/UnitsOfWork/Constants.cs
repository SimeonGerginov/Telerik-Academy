namespace UnitsOfWork
{
    public static class Constants
    {
        public const string AddCommand = "add";
        public const string RemoveCommand = "remove";
        public const string FindCommand = "find";
        public const string PowerCommand = "power";
        public const string TerminationCommand = "end";

        public const int UnitsToTake = 10;

        public const int UnitNameMinLength = 1;
        public const int UnitNameMaxLength = 30;
        public const string UnitNameError = "The name of the unit must be between {0} and {1} symbols!";

        public const int UnitTypeMinLength = 1;
        public const int UnitTypeMaxLength = 40;
        public const string UnitTypeError = "The type of the unit must be between {0} and {1} symbols!";

        public const int UnitMinAttack = 100;
        public const int UnitMaxAttack = 1000;
        public const string UnitAttackError = "The attack of the unit must be between {0} and {1}!";
    }
}
