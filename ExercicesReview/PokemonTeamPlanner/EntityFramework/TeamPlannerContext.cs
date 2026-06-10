using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTeamPlanner
{
    public class TeamPlannerContext : DbContext
    {
        public DbSet<PokemonTeam> PokemonTeams { get; set; } = null!;
        public DbSet<PokemonEntry> PokemonEntries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=..\..\..\teamplanner.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonTeam>().HasData(
               new PokemonTeam { Id = 1, Name = "Test Team", Description = "Test team for development purposes."}
            );
            modelBuilder.Entity<PokemonEntry>().HasData(
                new PokemonEntry { Id = 1, Name = "Bulbasaur", Url = "https://pokeapi.co/api/v2/pokemon/1/" }
            );
        }
    }
}
