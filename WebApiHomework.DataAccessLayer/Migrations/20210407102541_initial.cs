using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiHomework.DataAccessLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookEntities",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Language = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    PublishedYear = table.Column<int>(type: "int", nullable: false),
                    NumberOfPages = table.Column<int>(type: "int", nullable: false),
                    IsHardBook = table.Column<bool>(type: "bit", nullable: false),
                    RecommendedAge = table.Column<int>(type: "int", nullable: false),
                    StockNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookEntities", x => x.BookId);
                });

            migrationBuilder.InsertData(
                table: "BookEntities",
                columns: new[] { "BookId", "Author", "Genre", "IsHardBook", "Language", "Name", "NumberOfPages", "PublishedYear", "RecommendedAge", "StockNumber" },
                values: new object[] { 1, "R.L. Stein", null, false, null, "Ghoosebumps", 0, 0, 0, 0 });

            migrationBuilder.InsertData(
                table: "BookEntities",
                columns: new[] { "BookId", "Author", "Genre", "IsHardBook", "Language", "Name", "NumberOfPages", "PublishedYear", "RecommendedAge", "StockNumber" },
                values: new object[] { 2, "G.R. Martin", null, false, null, "Game of thrones", 0, 0, 0, 0 });

            migrationBuilder.InsertData(
                table: "BookEntities",
                columns: new[] { "BookId", "Author", "Genre", "IsHardBook", "Language", "Name", "NumberOfPages", "PublishedYear", "RecommendedAge", "StockNumber" },
                values: new object[] { 3, "Homer", null, false, null, "Iliada", 0, 0, 0, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookEntities");
        }
    }
}
