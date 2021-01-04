using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicController.Entites.Migrations
{
    public partial class changecloumntypeofplaylisttostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Playlists",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ImageUrl",
                value: "Images/Baladna.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ImageUrl",
                value: "Images/Basta.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ImageUrl",
                value: "Images/Build It Burger.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 4L,
                column: "ImageUrl",
                value: "Images/Debs w Remman.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 5L,
                column: "ImageUrl",
                value: "Images/Gahwetna.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 6L,
                column: "ImageUrl",
                value: "Images/Jwala.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 7L,
                column: "ImageUrl",
                value: "Images/Karaki.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 8L,
                column: "ImageUrl",
                value: "Images/La Casa.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 9L,
                column: "ImageUrl",
                value: "Images/Maia.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 10L,
                column: "ImageUrl",
                value: "Images/Meatsmith.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 11L,
                column: "ImageUrl",
                value: "Images/Mokarabia.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 12L,
                column: "ImageUrl",
                value: "Images/Orient Pearl.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 13L,
                column: "ImageUrl",
                value: "Images/Palma.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 14L,
                column: "ImageUrl",
                value: "Images/Remman Cafe.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 15L,
                column: "ImageUrl",
                value: "Images/Sazeli Logo.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 16L,
                column: "ImageUrl",
                value: "Images/SMAT.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 17L,
                column: "ImageUrl",
                value: "Images/USTA.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Playlists",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ImageUrl",
                value: "/Images/Baladna.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ImageUrl",
                value: "/Images/Basta.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ImageUrl",
                value: "/Images/Build It Burger.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 4L,
                column: "ImageUrl",
                value: "/Images/Debs w Remman.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 5L,
                column: "ImageUrl",
                value: "/Images/Gahwetna.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 6L,
                column: "ImageUrl",
                value: "/Images/Jwala.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 7L,
                column: "ImageUrl",
                value: "/Images/Karaki.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 8L,
                column: "ImageUrl",
                value: "/Images/La Casa.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 9L,
                column: "ImageUrl",
                value: "/Images/Maia.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 10L,
                column: "ImageUrl",
                value: "/Images/Meatsmith.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 11L,
                column: "ImageUrl",
                value: "/Images/Mokarabia.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 12L,
                column: "ImageUrl",
                value: "/Images/Orient Pearl.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 13L,
                column: "ImageUrl",
                value: "/Images/Palma.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 14L,
                column: "ImageUrl",
                value: "/Images/Remman Cafe.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 15L,
                column: "ImageUrl",
                value: "/Images/Sazeli Logo.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 16L,
                column: "ImageUrl",
                value: "/Images/SMAT.png");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 17L,
                column: "ImageUrl",
                value: "/Images/USTA.png");
        }
    }
}
