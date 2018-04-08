namespace SchoolSystem.CLI.Constants
{
    public static class GlobalConstants
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 31;

        public const float MinValue = 2;
        public const float MaxValue = 6;

        public const int MaxMarkCountPerStudent = 20;

        public const string TerminationCommand = "END";

        public const string NameErrorMessage = "Name must be between 2 and 31 symbols long!";
        public const string NameCharactersErrorMessage = "Name must contaion only latin letters!";
        public const string NullErrorMessage = "Value cannot be null!";
        public const string ValueErrorMessage = "Value must be between 2 and 6!";
        public const string MarkCountErrorMessage = "One student cannot have more than 20 marks!";

        public const string CommandNullErrorMessage = "Command cannot be null!";
        public const string ReaderNullErrorMessage = "Reader cannot be null!";
        public const string WriterNullErrorMessage = "Writer cannot be null!";
        public const string ParserNullErrorMessage = "Parser cannot be null!";

        public const string NotFoundStudentErrorMessage = "The dictionary of students does not contain a student with that id!";
        public const string NotFoundPersonErrorMessage = "The dictionary does not contain a person with that id!";
    }
}
