using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace PokemonTeamPlanner
{
    public class TeamPlannerDatabaseServices
    {
        private readonly TeamPlannerContext _context = new TeamPlannerContext();

        //CRUD operations for PokemonTeam and PokemonEntry entities will be implemented here in the future.
        //Creates

        //Reads

        public async Task<List<PokemonEntry>> GetAllPokemon()
        {
            List<PokemonEntry> pokemonEntries = await _context.PokemonEntries.ToListAsync();

            return pokemonEntries;
        }

        //Updates

        //Deletes
    }
}
