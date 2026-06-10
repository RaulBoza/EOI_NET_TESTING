using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonTeamPlanner.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PokemonTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PokemonEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    PokemonTeamId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokemonEntries_PokemonTeams_PokemonTeamId",
                        column: x => x.PokemonTeamId,
                        principalTable: "PokemonTeams",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "PokemonEntries",
                columns: new[] { "Id", "Name", "PokemonTeamId", "Url" },
                values: new object[] { 1, "Bulbasaur", null, "https://pokeapi.co/api/v2/pokemon/1/" });

            migrationBuilder.InsertData(
                table: "PokemonTeams",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Test team for development purposes.", "Test Team" });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonEntries_PokemonTeamId",
                table: "PokemonEntries",
                column: "PokemonTeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonEntries");

            migrationBuilder.DropTable(
                name: "PokemonTeams");
        }
    }
}
