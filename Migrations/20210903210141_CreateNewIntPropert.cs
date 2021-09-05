using Microsoft.EntityFrameworkCore.Migrations;

namespace homework_56.Migrations
{
    public partial class CreateNewIntPropert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriorityKey",
                table: "Tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusKey",
                table: "Tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriorityKey",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "StatusKey",
                table: "Tasks");
        }
    }
}
