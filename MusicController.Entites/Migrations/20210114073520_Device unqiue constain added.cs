using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicController.Entites.Migrations
{
    public partial class Deviceunqiueconstainadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Salt",
                table: "Outlets",
                nullable: false,
                defaultValue: new byte[] { 232, 63, 103, 199, 159, 32, 175, 186, 224, 8, 133, 205, 135, 54, 128, 61 },
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldDefaultValue: new byte[] { 254, 232, 178, 252, 185, 218, 129, 193, 118, 110, 173, 241, 81, 158, 88, 218 });

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Outlets",
                maxLength: 256,
                nullable: false,
                defaultValue: "vBSh2uUo67DpUFJ2456El/9dAXt//TQqXt2HDbG1IIo=",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldDefaultValue: "tzKstRjR2pcrrmES5pp6I0GM+Ipq4CPQLfrSpyy+kqY=");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "1dk3nZEwnRqtA9Wj+fXaKbj1iN2OFKJk/H8q8pPGAzQ=", new byte[] { 71, 71, 135, 18, 46, 19, 138, 27, 132, 129, 223, 116, 108, 205, 198, 56 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "1dk3nZEwnRqtA9Wj+fXaKbj1iN2OFKJk/H8q8pPGAzQ=", new byte[] { 71, 71, 135, 18, 46, 19, 138, 27, 132, 129, 223, 116, 108, 205, 198, 56 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "1dk3nZEwnRqtA9Wj+fXaKbj1iN2OFKJk/H8q8pPGAzQ=", new byte[] { 71, 71, 135, 18, 46, 19, 138, 27, 132, 129, 223, 116, 108, 205, 198, 56 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "1dk3nZEwnRqtA9Wj+fXaKbj1iN2OFKJk/H8q8pPGAzQ=", new byte[] { 71, 71, 135, 18, 46, 19, 138, 27, 132, 129, 223, 116, 108, 205, 198, 56 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "1dk3nZEwnRqtA9Wj+fXaKbj1iN2OFKJk/H8q8pPGAzQ=", new byte[] { 71, 71, 135, 18, 46, 19, 138, 27, 132, 129, 223, 116, 108, 205, 198, 56 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "1dk3nZEwnRqtA9Wj+fXaKbj1iN2OFKJk/H8q8pPGAzQ=", new byte[] { 71, 71, 135, 18, 46, 19, 138, 27, 132, 129, 223, 116, 108, 205, 198, 56 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "1dk3nZEwnRqtA9Wj+fXaKbj1iN2OFKJk/H8q8pPGAzQ=", new byte[] { 71, 71, 135, 18, 46, 19, 138, 27, 132, 129, 223, 116, 108, 205, 198, 56 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "1dk3nZEwnRqtA9Wj+fXaKbj1iN2OFKJk/H8q8pPGAzQ=", new byte[] { 71, 71, 135, 18, 46, 19, 138, 27, 132, 129, 223, 116, 108, 205, 198, 56 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "1dk3nZEwnRqtA9Wj+fXaKbj1iN2OFKJk/H8q8pPGAzQ=", new byte[] { 71, 71, 135, 18, 46, 19, 138, 27, 132, 129, 223, 116, 108, 205, 198, 56 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "1dk3nZEwnRqtA9Wj+fXaKbj1iN2OFKJk/H8q8pPGAzQ=", new byte[] { 71, 71, 135, 18, 46, 19, 138, 27, 132, 129, 223, 116, 108, 205, 198, 56 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "1dk3nZEwnRqtA9Wj+fXaKbj1iN2OFKJk/H8q8pPGAzQ=", new byte[] { 71, 71, 135, 18, 46, 19, 138, 27, 132, 129, 223, 116, 108, 205, 198, 56 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "1dk3nZEwnRqtA9Wj+fXaKbj1iN2OFKJk/H8q8pPGAzQ=", new byte[] { 71, 71, 135, 18, 46, 19, 138, 27, 132, 129, 223, 116, 108, 205, 198, 56 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "1dk3nZEwnRqtA9Wj+fXaKbj1iN2OFKJk/H8q8pPGAzQ=", new byte[] { 71, 71, 135, 18, 46, 19, 138, 27, 132, 129, 223, 116, 108, 205, 198, 56 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "1dk3nZEwnRqtA9Wj+fXaKbj1iN2OFKJk/H8q8pPGAzQ=", new byte[] { 71, 71, 135, 18, 46, 19, 138, 27, 132, 129, 223, 116, 108, 205, 198, 56 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "1dk3nZEwnRqtA9Wj+fXaKbj1iN2OFKJk/H8q8pPGAzQ=", new byte[] { 71, 71, 135, 18, 46, 19, 138, 27, 132, 129, 223, 116, 108, 205, 198, 56 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "1dk3nZEwnRqtA9Wj+fXaKbj1iN2OFKJk/H8q8pPGAzQ=", new byte[] { 71, 71, 135, 18, 46, 19, 138, 27, 132, 129, 223, 116, 108, 205, 198, 56 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "1dk3nZEwnRqtA9Wj+fXaKbj1iN2OFKJk/H8q8pPGAzQ=", new byte[] { 71, 71, 135, 18, 46, 19, 138, 27, 132, 129, 223, 116, 108, 205, 198, 56 } });

            migrationBuilder.CreateIndex(
                name: "IX_Device_DeviceId",
                table: "Device",
                column: "DeviceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Device_DeviceId",
                table: "Device");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Salt",
                table: "Outlets",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[] { 254, 232, 178, 252, 185, 218, 129, 193, 118, 110, 173, 241, 81, 158, 88, 218 },
                oldClrType: typeof(byte[]),
                oldDefaultValue: new byte[] { 232, 63, 103, 199, 159, 32, 175, 186, 224, 8, 133, 205, 135, 54, 128, 61 });

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Outlets",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "tzKstRjR2pcrrmES5pp6I0GM+Ipq4CPQLfrSpyy+kqY=",
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldDefaultValue: "vBSh2uUo67DpUFJ2456El/9dAXt//TQqXt2HDbG1IIo=");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 } });
        }
    }
}
