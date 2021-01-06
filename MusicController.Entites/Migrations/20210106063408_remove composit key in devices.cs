using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicController.Entites.Migrations
{
    public partial class removecompositkeyindevices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Device",
                table: "Device");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceId",
                table: "Device",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Device",
                table: "Device",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Device_OutletId",
                table: "Device",
                column: "OutletId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Device",
                table: "Device");

            migrationBuilder.DropIndex(
                name: "IX_Device_OutletId",
                table: "Device");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceId",
                table: "Device",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Device",
                table: "Device",
                columns: new[] { "OutletId", "DeviceId" });
        }
    }
}
