using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;


namespace PokemonTeamPlanner
{
    static class PokemonApiServices
    {
        /// <summary>
        /// Retrieves the list of all Pokémon.
        /// </summary>
        /// <returns>A task representing the List of all Pokémon</returns>
        public static async Task<PokemonList> GetPokemonList()
        {
            HttpClient client = new HttpClient();
            string url = $"https://pokeapi.co/api/v2/pokemon?limit=1350&offset=0";
            string response = await client.GetStringAsync(url);

            PokemonList pokemonList = JsonSerializer.Deserialize<PokemonList>(response);
            pokemonList.Results.ToList()
                .ForEach(p => Console.WriteLine(p.Name));
            return pokemonList;
        }

        public static async Task<PokemonEntry> GetPokemonByName(string name)
        {
            HttpClient client = new HttpClient();
            string url = $"https://pokeapi.co/api/v2/pokemon/{name}";

            try
            {
                string response = await client.GetStringAsync(url);
                PokemonEntry pokemonEntry = JsonSerializer.Deserialize<PokemonEntry>(response);
                Console.WriteLine(pokemonEntry.Name);
                return pokemonEntry;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while fetching Pokémon data.");
            }

            return null;

        }

    }
}
