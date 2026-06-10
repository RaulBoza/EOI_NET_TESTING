//https://pokeapi.co/api/v2/
//https://pokeapi.co/api/v2/pokemon?limit=100000&offset=0
//https://pokeapi.co/api/v2/pokemon/1
//https://pokeapi.co/api/v2/ability/1

using System.Text.Json;

namespace PokemonTeamPlanner
{
    internal class Program
    {
        static TeamPlannerDatabaseServices servicies = new TeamPlannerDatabaseServices();
        static async Task Main(string[] args)
        {
            //PokemonList pokemonList = await PokemonApiServices.GetPokemonList();
            //PokemonEntry pokemon = await PokemonApiServices.GetPokemonByName("bulbasur");
            List<PokemonEntry> pokemonEntries = await servicies.GetAllPokemon();
            pokemonEntries.ForEach(p => Console.WriteLine(p.Name));
        }
        
    }
}
