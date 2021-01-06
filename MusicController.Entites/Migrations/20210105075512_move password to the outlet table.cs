using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicController.Entites.Migrations
{
    public partial class movepasswordtotheoutlettable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Device");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Outlets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Outlets");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Device",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
