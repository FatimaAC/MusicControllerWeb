using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicController.Entites.Migrations
{
    public partial class defaultvalueinoutletforpasswordandsaltandtracktimespancloumnadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Salt",
                table: "Outlets",
                nullable: false,
                defaultValue: new byte[] { 47, 122, 142, 84, 36, 114, 222, 212, 247, 75, 131, 54, 208, 232, 153, 116 },
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldDefaultValue: new byte[] { 63, 8, 161, 89, 134, 118, 105, 20, 236, 201, 120, 115, 236, 97, 184, 35 });

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Outlets",
                maxLength: 256,
                nullable: false,
                defaultValue: "tqtFg6GP9zMJW552sZXy6GiMDxLIl0HioSwIbJYN77I=",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldDefaultValue: "GJ8KvGdjh5y4zEgxGz5/Zu1ux1SYZpeOHadFAVzToJs=");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "HayKL7Pp78yVR2dzeWxbXd1h982hE0HjxUmPH2UhipA=", new byte[] { 66, 40, 108, 253, 63, 230, 93, 233, 13, 189, 122, 95, 114, 186, 150, 110 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "HayKL7Pp78yVR2dzeWxbXd1h982hE0HjxUmPH2UhipA=", new byte[] { 66, 40, 108, 253, 63, 230, 93, 233, 13, 189, 122, 95, 114, 186, 150, 110 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "HayKL7Pp78yVR2dzeWxbXd1h982hE0HjxUmPH2UhipA=", new byte[] { 66, 40, 108, 253, 63, 230, 93, 233, 13, 189, 122, 95, 114, 186, 150, 110 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "HayKL7Pp78yVR2dzeWxbXd1h982hE0HjxUmPH2UhipA=", new byte[] { 66, 40, 108, 253, 63, 230, 93, 233, 13, 189, 122, 95, 114, 186, 150, 110 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "HayKL7Pp78yVR2dzeWxbXd1h982hE0HjxUmPH2UhipA=", new byte[] { 66, 40, 108, 253, 63, 230, 93, 233, 13, 189, 122, 95, 114, 186, 150, 110 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "HayKL7Pp78yVR2dzeWxbXd1h982hE0HjxUmPH2UhipA=", new byte[] { 66, 40, 108, 253, 63, 230, 93, 233, 13, 189, 122, 95, 114, 186, 150, 110 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "HayKL7Pp78yVR2dzeWxbXd1h982hE0HjxUmPH2UhipA=", new byte[] { 66, 40, 108, 253, 63, 230, 93, 233, 13, 189, 122, 95, 114, 186, 150, 110 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "HayKL7Pp78yVR2dzeWxbXd1h982hE0HjxUmPH2UhipA=", new byte[] { 66, 40, 108, 253, 63, 230, 93, 233, 13, 189, 122, 95, 114, 186, 150, 110 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "HayKL7Pp78yVR2dzeWxbXd1h982hE0HjxUmPH2UhipA=", new byte[] { 66, 40, 108, 253, 63, 230, 93, 233, 13, 189, 122, 95, 114, 186, 150, 110 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "HayKL7Pp78yVR2dzeWxbXd1h982hE0HjxUmPH2UhipA=", new byte[] { 66, 40, 108, 253, 63, 230, 93, 233, 13, 189, 122, 95, 114, 186, 150, 110 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "HayKL7Pp78yVR2dzeWxbXd1h982hE0HjxUmPH2UhipA=", new byte[] { 66, 40, 108, 253, 63, 230, 93, 233, 13, 189, 122, 95, 114, 186, 150, 110 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "HayKL7Pp78yVR2dzeWxbXd1h982hE0HjxUmPH2UhipA=", new byte[] { 66, 40, 108, 253, 63, 230, 93, 233, 13, 189, 122, 95, 114, 186, 150, 110 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "HayKL7Pp78yVR2dzeWxbXd1h982hE0HjxUmPH2UhipA=", new byte[] { 66, 40, 108, 253, 63, 230, 93, 233, 13, 189, 122, 95, 114, 186, 150, 110 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "HayKL7Pp78yVR2dzeWxbXd1h982hE0HjxUmPH2UhipA=", new byte[] { 66, 40, 108, 253, 63, 230, 93, 233, 13, 189, 122, 95, 114, 186, 150, 110 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "HayKL7Pp78yVR2dzeWxbXd1h982hE0HjxUmPH2UhipA=", new byte[] { 66, 40, 108, 253, 63, 230, 93, 233, 13, 189, 122, 95, 114, 186, 150, 110 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "HayKL7Pp78yVR2dzeWxbXd1h982hE0HjxUmPH2UhipA=", new byte[] { 66, 40, 108, 253, 63, 230, 93, 233, 13, 189, 122, 95, 114, 186, 150, 110 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "HayKL7Pp78yVR2dzeWxbXd1h982hE0HjxUmPH2UhipA=", new byte[] { 66, 40, 108, 253, 63, 230, 93, 233, 13, 189, 122, 95, 114, 186, 150, 110 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "HayKL7Pp78yVR2dzeWxbXd1h982hE0HjxUmPH2UhipA=", new byte[] { 66, 40, 108, 253, 63, 230, 93, 233, 13, 189, 122, 95, 114, 186, 150, 110 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Salt",
                table: "Outlets",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[] { 63, 8, 161, 89, 134, 118, 105, 20, 236, 201, 120, 115, 236, 97, 184, 35 },
                oldClrType: typeof(byte[]),
                oldDefaultValue: new byte[] { 47, 122, 142, 84, 36, 114, 222, 212, 247, 75, 131, 54, 208, 232, 153, 116 });

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Outlets",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "GJ8KvGdjh5y4zEgxGz5/Zu1ux1SYZpeOHadFAVzToJs=",
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldDefaultValue: "tqtFg6GP9zMJW552sZXy6GiMDxLIl0HioSwIbJYN77I=");

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3/1yhAnpv+bF3jUO5X2WvjDfz0RycixokdrRbHl6Twc=", new byte[] { 53, 218, 106, 100, 59, 241, 192, 221, 18, 219, 233, 53, 169, 62, 224, 15 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3/1yhAnpv+bF3jUO5X2WvjDfz0RycixokdrRbHl6Twc=", new byte[] { 53, 218, 106, 100, 59, 241, 192, 221, 18, 219, 233, 53, 169, 62, 224, 15 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3/1yhAnpv+bF3jUO5X2WvjDfz0RycixokdrRbHl6Twc=", new byte[] { 53, 218, 106, 100, 59, 241, 192, 221, 18, 219, 233, 53, 169, 62, 224, 15 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3/1yhAnpv+bF3jUO5X2WvjDfz0RycixokdrRbHl6Twc=", new byte[] { 53, 218, 106, 100, 59, 241, 192, 221, 18, 219, 233, 53, 169, 62, 224, 15 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3/1yhAnpv+bF3jUO5X2WvjDfz0RycixokdrRbHl6Twc=", new byte[] { 53, 218, 106, 100, 59, 241, 192, 221, 18, 219, 233, 53, 169, 62, 224, 15 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3/1yhAnpv+bF3jUO5X2WvjDfz0RycixokdrRbHl6Twc=", new byte[] { 53, 218, 106, 100, 59, 241, 192, 221, 18, 219, 233, 53, 169, 62, 224, 15 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3/1yhAnpv+bF3jUO5X2WvjDfz0RycixokdrRbHl6Twc=", new byte[] { 53, 218, 106, 100, 59, 241, 192, 221, 18, 219, 233, 53, 169, 62, 224, 15 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3/1yhAnpv+bF3jUO5X2WvjDfz0RycixokdrRbHl6Twc=", new byte[] { 53, 218, 106, 100, 59, 241, 192, 221, 18, 219, 233, 53, 169, 62, 224, 15 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3/1yhAnpv+bF3jUO5X2WvjDfz0RycixokdrRbHl6Twc=", new byte[] { 53, 218, 106, 100, 59, 241, 192, 221, 18, 219, 233, 53, 169, 62, 224, 15 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3/1yhAnpv+bF3jUO5X2WvjDfz0RycixokdrRbHl6Twc=", new byte[] { 53, 218, 106, 100, 59, 241, 192, 221, 18, 219, 233, 53, 169, 62, 224, 15 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3/1yhAnpv+bF3jUO5X2WvjDfz0RycixokdrRbHl6Twc=", new byte[] { 53, 218, 106, 100, 59, 241, 192, 221, 18, 219, 233, 53, 169, 62, 224, 15 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3/1yhAnpv+bF3jUO5X2WvjDfz0RycixokdrRbHl6Twc=", new byte[] { 53, 218, 106, 100, 59, 241, 192, 221, 18, 219, 233, 53, 169, 62, 224, 15 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3/1yhAnpv+bF3jUO5X2WvjDfz0RycixokdrRbHl6Twc=", new byte[] { 53, 218, 106, 100, 59, 241, 192, 221, 18, 219, 233, 53, 169, 62, 224, 15 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3/1yhAnpv+bF3jUO5X2WvjDfz0RycixokdrRbHl6Twc=", new byte[] { 53, 218, 106, 100, 59, 241, 192, 221, 18, 219, 233, 53, 169, 62, 224, 15 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3/1yhAnpv+bF3jUO5X2WvjDfz0RycixokdrRbHl6Twc=", new byte[] { 53, 218, 106, 100, 59, 241, 192, 221, 18, 219, 233, 53, 169, 62, 224, 15 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3/1yhAnpv+bF3jUO5X2WvjDfz0RycixokdrRbHl6Twc=", new byte[] { 53, 218, 106, 100, 59, 241, 192, 221, 18, 219, 233, 53, 169, 62, 224, 15 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3/1yhAnpv+bF3jUO5X2WvjDfz0RycixokdrRbHl6Twc=", new byte[] { 53, 218, 106, 100, 59, 241, 192, 221, 18, 219, 233, 53, 169, 62, 224, 15 } });

            migrationBuilder.UpdateData(
                table: "Outlets",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "3/1yhAnpv+bF3jUO5X2WvjDfz0RycixokdrRbHl6Twc=", new byte[] { 53, 218, 106, 100, 59, 241, 192, 221, 18, 219, 233, 53, 169, 62, 224, 15 } });
        }
    }
}
