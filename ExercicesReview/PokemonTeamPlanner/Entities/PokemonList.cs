using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PokemonTeamPlanner
{
    public class PokemonList
    {
        [JsonPropertyName("count")]
        public int Count { get; set; } = 0;

        [JsonPropertyName("next")]
        public string Next { get; set; } = string.Empty;

        [JsonPropertyName("previous")]
        public string Previous { get; set; } = string.Empty;

        [JsonPropertyName("results")]
        public List<PokemonEntry> Results { get; set; }


    }

        

    
}
