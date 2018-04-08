using SchoolSystem.CLI.Enums;

namespace SchoolSystem.CLI.Models.Contracts
{
    /// <summary>
    /// Represents the Mark Students get from Teachers during class, that contains the Mark's subject and value.
    /// </summary>
    public interface IMark
    {
        float Value { get; set; }

        Subject Subject { get; set; }
    }
}
