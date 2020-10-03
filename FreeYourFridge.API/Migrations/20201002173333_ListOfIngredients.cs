using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeYourFridge.API.Migrations
{
    public partial class ListOfIngredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListOfIngredients",
                columns: table => new
                {
                    originalName = table.Column<string>(nullable: false),
                    id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfIngredients", x => x.originalName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListOfIngredients");
        }
    }
}
