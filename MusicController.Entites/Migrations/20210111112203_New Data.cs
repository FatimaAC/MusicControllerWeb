using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MusicController.Entites.Migrations
{
    public partial class NewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Outlets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 450, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Description = table.Column<string>(maxLength: 128, nullable: true),
                    ImageUrl = table.Column<string>(maxLength: 256, nullable: false),
                    Password = table.Column<string>(maxLength: 256, nullable: false, defaultValue: "tzKstRjR2pcrrmES5pp6I0GM+Ipq4CPQLfrSpyy+kqY="),
                    Salt = table.Column<byte[]>(nullable: false, defaultValue: new byte[] { 254, 232, 178, 252, 185, 218, 129, 193, 118, 110, 173, 241, 81, 158, 88, 218 })
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outlets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutletId = table.Column<long>(nullable: false),
                    DeviceId = table.Column<string>(maxLength: 16, nullable: false),
                    DeviceDetail = table.Column<string>(maxLength: 256, nullable: true),
                    StatusMessage = table.Column<string>(maxLength: 256, nullable: true),
                    StatusPostedAt = table.Column<DateTime>(nullable: true),
                    RequestedAt = table.Column<DateTime>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: false),
                    ApprovedBy = table.Column<string>(maxLength: 450, nullable: true),
                    ApprovedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Device_Outlets_OutletId",
                        column: x => x.OutletId,
                        principalTable: "Outlets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 450, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OutletId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Schedule = table.Column<string>(maxLength: 256, nullable: false),
                    Frequency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlists_Outlets_OutletId",
                        column: x => x.OutletId,
                        principalTable: "Outlets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaylistId = table.Column<long>(nullable: false),
                    TrackURL = table.Column<string>(maxLength: 256, nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Outlets",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "ImageUrl", "Name", "Password", "Salt", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, null, null, null, "Images/Baladna.png", "Baladna", "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 }, null, null },
                    { 16L, null, null, null, "Images/SMAT.png", "SMAT", "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 }, null, null },
                    { 15L, null, null, null, "Images/Sazeli Logo.png", "Sazeli Logo", "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 }, null, null },
                    { 14L, null, null, null, "Images/Remman Cafe.png", "Remman Cafe", "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 }, null, null },
                    { 12L, null, null, null, "Images/Orient Pearl.png", "Orient Pearl", "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 }, null, null },
                    { 11L, null, null, null, "Images/Mokarabia.png", "Mokarabia", "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 }, null, null },
                    { 10L, null, null, null, "Images/Meatsmith.png", "Meatsmith", "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 }, null, null },
                    { 17L, null, null, null, "Images/USTA.png", "USTA", "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 }, null, null },
                    { 9L, null, null, null, "Images/Maia.png", "Maia", "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 }, null, null },
                    { 7L, null, null, null, "Images/Karaki.png", "Karaki", "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 }, null, null },
                    { 6L, null, null, null, "Images/Jwala.png", "Jwala", "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 }, null, null },
                    { 5L, null, null, null, "Images/Gahwetna.png", "Gahwetna", "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 }, null, null },
                    { 4L, null, null, null, "Images/Debs w Remman.png", "Debs w Remman", "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 }, null, null },
                    { 3L, null, null, null, "Images/Build It Burger.png", "Build It Burger", "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 }, null, null },
                    { 2L, null, null, null, "Images/Basta.png", "Basta", "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 }, null, null },
                    { 8L, null, null, null, "Images/La Casa.png", "La Casa", "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 }, null, null },
                    { 18L, null, null, null, "Images/USTA.png", "USTA Remove", "m/68YrUbnbRIbiXqJdgTypKZMqE4LzZil09L9bT6Ajs=", new byte[] { 74, 207, 202, 38, 163, 145, 35, 100, 20, 111, 253, 51, 1, 147, 26, 54 }, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Device_OutletId",
                table: "Device",
                column: "OutletId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_OutletId",
                table: "Playlists",
                column: "OutletId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_PlaylistId",
                table: "Tracks",
                column: "PlaylistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Outlets");
        }
    }
}
