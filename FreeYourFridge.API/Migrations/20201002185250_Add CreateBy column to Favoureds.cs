using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeYourFridge.API.Migrations
{
    public partial class AddCreateBycolumntoFavoureds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Favoureds",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Favoureds");
        }
    }
}
