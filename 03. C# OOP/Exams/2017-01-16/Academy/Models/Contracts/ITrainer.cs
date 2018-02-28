namespace Academy.Models.Contracts
{
    using System.Collections.Generic;

    public interface ITrainer : IUser
    {
        IList<string> Technologies { get; set; }
    }
}
