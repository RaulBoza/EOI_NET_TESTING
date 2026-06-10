using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestorPrestaciones.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellidos = table.Column<string>(type: "TEXT", nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DNI = table.Column<string>(type: "TEXT", nullable: false),
                    Sexo = table.Column<string>(type: "TEXT", nullable: false),
                    BaseReguladora = table.Column<int>(type: "INTEGER", nullable: false),
                    GradoDiscapacidad = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trabajos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    EsDeRiesgo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntervalosBaja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Inicio = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Fin = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntervalosBaja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntervalosBaja_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalPerestacion = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestaciones_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IntervalosTrabajo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TrabajoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Inicio = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Fin = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntervalosTrabajo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntervalosTrabajo_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IntervalosTrabajo_Trabajos_TrabajoId",
                        column: x => x.TrabajoId,
                        principalTable: "Trabajos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Apellidos", "BaseReguladora", "DNI", "FechaNacimiento", "GradoDiscapacidad", "Nombre", "Sexo" },
                values: new object[,]
                {
                    { 1, "Pérez", 0, "12345678A", new DateOnly(1980, 5, 15), 0, "Juan", "Masculino" },
                    { 2, "García", 0, "87654321B", new DateOnly(1990, 8, 20), 0, "María", "Femenino" }
                });

            migrationBuilder.InsertData(
                table: "Trabajos",
                columns: new[] { "Id", "Descripcion", "EsDeRiesgo", "Nombre" },
                values: new object[,]
                {
                    { 1, "Trabajo en minas subterráneas", true, "Minero" },
                    { 2, "Trabajo en caja de supermercado", false, "Cajero" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IntervalosBaja_ClienteId",
                table: "IntervalosBaja",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_IntervalosTrabajo_ClienteId",
                table: "IntervalosTrabajo",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_IntervalosTrabajo_TrabajoId",
                table: "IntervalosTrabajo",
                column: "TrabajoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestaciones_ClienteId",
                table: "Prestaciones",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntervalosBaja");

            migrationBuilder.DropTable(
                name: "IntervalosTrabajo");

            migrationBuilder.DropTable(
                name: "Prestaciones");

            migrationBuilder.DropTable(
                name: "Trabajos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
