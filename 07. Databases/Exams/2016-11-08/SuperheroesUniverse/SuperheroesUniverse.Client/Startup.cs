using SuperheroesUniverse.Client.Exporters;
using SuperheroesUniverse.Client.Importers;
using SuperheroesUniverse.Data;

namespace SuperheroesUniverse.Client
{
    public class Startup
    {
        public static void Main()
        {
            SuperheroesUniverseDbContext context = new SuperheroesUniverseDbContext();

            // importers
            JsonSuperheroesImporter jsonImporter = new JsonSuperheroesImporter(context);
            jsonImporter.LoadSuperheroesData("../../Data/sample-data.json");

            // exporters
            SuperheroesUniverseExporter xmlExporter = new SuperheroesUniverseExporter(context, "../../heroes.xml");
            xmlExporter.ExportAllSuperheroes();
        }
    }
}
