namespace SuperheroesUniverse.Client.Importers.Contracts
{
    public interface ISuperheroesImporter
    {
        void LoadSuperheroesData(string filePath);
    }
}
