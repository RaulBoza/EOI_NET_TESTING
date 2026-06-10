using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PokemonTeamPlanner
{
    public class PokemonTeam
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("team_members")]
        public ICollection<PokemonEntry> TeamMembers { get; set; } = new List<PokemonEntry>();

        //[JsonPropertyName("team_bench")]
        //public ICollection<PokemonEntry> TeamBench { get; set; } = new List<PokemonEntry>();

    }
}
