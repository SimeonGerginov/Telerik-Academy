using System.Collections.Generic;
using Newtonsoft.Json;

namespace SuperheroesUniverse.Client.Importers.JsonModels
{
    public class SuperheroesCollectionJsonModel
    {
        [JsonProperty("data")]
        public IEnumerable<SuperheroJsonModel> Superheroes { get; set; }
    }
}
