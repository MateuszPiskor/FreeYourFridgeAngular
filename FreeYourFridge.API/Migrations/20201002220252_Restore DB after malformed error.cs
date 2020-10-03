using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeYourFridge.API.Migrations
{
    public partial class RestoreDBaftermalformederror : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyMeals",
                columns: table => new
                {
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
                    table.PrimaryKey("PK_DailyMeals", x => x.LocalId);
                });

            migrationBuilder.CreateTable(
                name: "Favoureds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    SpoonacularId = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    CreateTime = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoureds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    SpoonacularId = table.Column<int>(nullable: false),
                    Grams = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingListItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpoonacularId = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Unit = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IsOnShoppingList = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    Height = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DailyDemand = table.Column<int>(nullable: false),
                    Carbohydrates = table.Column<int>(nullable: false),
                    Fats = table.Column<int>(nullable: false),
                    Protein = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersDetails_UserId",
                table: "UsersDetails",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyMeals");

            migrationBuilder.DropTable(
                name: "Favoureds");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "ShoppingListItems");

            migrationBuilder.DropTable(
                name: "UsersDetails");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
