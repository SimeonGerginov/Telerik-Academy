namespace IntergalacticTravel.Contracts
{
    public interface IResourcesFactory
    {
        IResources GetResources(string command);
    }
}
