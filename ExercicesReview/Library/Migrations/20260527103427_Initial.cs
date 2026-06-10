using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    ISBN = table.Column<string>(type: "TEXT", nullable: false),
                    PublicationYear = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorsBooks",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "INTEGER", nullable: false),
                    BooksId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorsBooks", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_AuthorsBooks_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorsBooks_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "United Kingdom", "J.K. Rowling" },
                    { 2, "United States", "George R.R. Martin" },
                    { 3, "United Kingdom", "J.R.R. Tolkien" },
                    { 4, "United Kingdom", "Agatha Christie" },
                    { 5, "United States", "Stephen King" },
                    { 6, "United States", "Isaac Asimov" },
                    { 7, "United Kingdom", "Arthur C. Clarke" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "ISBN", "PublicationYear", "Title" },
                values: new object[,]
                {
                    { 1, "", 1997, "Harry Potter and the Philosopher's Stone" },
                    { 2, "", 1998, "Harry Potter and the Chamber of Secrets" },
                    { 3, "", 1999, "Harry Potter and the Prisoner of Azkaban" },
                    { 4, "", 1996, "A Game of Thrones" },
                    { 5, "", 1998, "A Clash of Kings" },
                    { 6, "", 1954, "The Lord of the Rings" },
                    { 7, "", 1937, "The Hobbit" },
                    { 8, "", 1934, "Murder on the Orient Express" },
                    { 9, "", 1977, "The Shining" },
                    { 10, "", 1951, "Foundation" },
                    { 11, "", 1968, "2001: A Space Odyssey" }
                });

            migrationBuilder.InsertData(
                table: "AuthorsBooks",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 3, 6 },
                    { 3, 7 },
                    { 4, 8 },
                    { 5, 9 },
                    { 6, 10 },
                    { 7, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsBooks_BooksId",
                table: "AuthorsBooks",
                column: "BooksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorsBooks");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
