using SchoolSystem.CLI.Enums;

namespace SchoolSystem.CLI.Models.Contracts
{
    public interface IMark
    {
        float Value { get; set; }

        Subject Subject { get; set; }
    }
}
