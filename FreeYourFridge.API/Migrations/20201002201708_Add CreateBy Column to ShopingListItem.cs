using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeYourFridge.API.Migrations
{
    public partial class AddCreateByColumntoShopingListItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "ToDoItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "ToDoItems");
        }
    }
}
