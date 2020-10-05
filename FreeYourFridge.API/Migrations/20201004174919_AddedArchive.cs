using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeYourFridge.API.Migrations
{
    public partial class AddedArchive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArchivedDailyMeals",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    DateTimeAddDeailyMeal = table.Column<DateTime>(nullable: false),
                    LocalId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    TimeOfLastMeal = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Grams = table.Column<int>(nullable: false),
                    UserRemarks = table.Column<string>(nullable: true),
                    Calories = table.Column<int>(nullable: false),
                    Carbs = table.Column<int>(nullable: false),
                    Fat = table.Column<int>(nullable: false),
                    Protein = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivedDailyMeals", x => x.Guid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivedDailyMeals");
        }
    }
}
