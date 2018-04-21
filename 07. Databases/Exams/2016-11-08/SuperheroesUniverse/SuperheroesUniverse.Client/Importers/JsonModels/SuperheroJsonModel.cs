using System.Collections.Generic;
using Newtonsoft.Json;

namespace SuperheroesUniverse.Client.Importers.JsonModels
{
    public class SuperheroJsonModel
    {
        public SuperheroJsonModel()
        {
            this.Powers = new List<string>();
            this.Fractions = new List<string>();
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("secretIdentity")]
        public string SecretIdentity { get; set; }

        [JsonProperty("city")]
        public CityJsonModel City { get; set; }

        [JsonProperty("alignment")]
        public string Alignment { get; set; }

        [JsonProperty("story")]
        public string Story { get; set; }

        [JsonProperty("powers")]
        public IEnumerable<string> Powers { get; set; }

        [JsonProperty("fractions")]
        public IEnumerable<string> Fractions { get; set; }
    }
}
