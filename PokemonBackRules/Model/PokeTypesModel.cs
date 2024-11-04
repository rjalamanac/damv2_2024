using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokemonBackRules.Model
{

    public class PokeTypesModel
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("previous")]
        public string Previous { get; set; }

        [JsonPropertyName("results")]
        public List<Types> Results { get; set; }
    }

    public class Types
    {
        [JsonPropertyName("name")]
        public string NombreType { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
