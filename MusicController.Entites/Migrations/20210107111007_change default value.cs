using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicController.Entites.Migrations
{
    public partial class changedefaultvalue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Salt",
                table: "Outlets",
                nullable: false,
                defaultValue: new byte[] { 78, 229, 18, 75, 149, 210, 104, 120, 45, 167, 210, 117, 178, 174, 147, 8 },
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Outlets",
                maxLength: 256,
                nullable: false,
                defaultValue: "ZNtgmw/aIxxfnrPmMlGWJ+PjM8ifiqTLsNoXba/oz4w=",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldDefaultValue: "Welcome123");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Salt",
                table: "Outlets",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldDefaultValue: new byte[] { 78, 229, 18, 75, 149, 210, 104, 120, 45, 167, 210, 117, 178, 174, 147, 8 });

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Outlets",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "Welcome123",
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldDefaultValue: "ZNtgmw/aIxxfnrPmMlGWJ+PjM8ifiqTLsNoXba/oz4w=");
        }
    }
}
