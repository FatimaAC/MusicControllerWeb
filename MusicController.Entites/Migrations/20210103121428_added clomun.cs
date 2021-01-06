using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MusicController.Entites.Migrations
{
    public partial class addedclomun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Outlets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApprovedBy = table.Column<string>(nullable: true),
                    ApprovedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outlets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    OutletId = table.Column<long>(nullable: false),
                    DeviceId = table.Column<string>(nullable: false),
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceDetail = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    StatusMessage = table.Column<string>(nullable: true),
                    StatusPostedAt = table.Column<string>(nullable: true),
                    RequestedAt = table.Column<DateTime>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: false),
                    ApprovedBy = table.Column<string>(nullable: true),
                    ApprovedAt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => new { x.OutletId, x.DeviceId });
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
                    ApprovedBy = table.Column<string>(nullable: true),
                    ApprovedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OutletId = table.Column<long>(nullable: false),
                    Name = table.Column<int>(nullable: false),
                    Schedule = table.Column<string>(nullable: true),
                    Frequency = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlists_Outlets_OutletId",
                        column: x => x.OutletId,
                        principalTable: "Outlets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaylistId = table.Column<long>(nullable: false),
                    TrackURL = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Outlets",
                columns: new[] { "Id", "ApprovedAt", "ApprovedBy", "CreatedAt", "CreatedBy", "Description", "ImageUrl", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, null, null, null, null, null, "/Images/Baladna.png", "Baladna", null, null },
                    { 15L, null, null, null, null, null, "/Images/Sazeli Logo.png", "Sazeli Logo", null, null },
                    { 14L, null, null, null, null, null, "/Images/Remman Cafe.png", "Remman Cafe", null, null },
                    { 13L, null, null, null, null, null, "/Images/Palma.png", "Palma", null, null },
                    { 12L, null, null, null, null, null, "/Images/Orient Pearl.png", "Orient Pearl", null, null },
                    { 11L, null, null, null, null, null, "/Images/Mokarabia.png", "Mokarabia", null, null },
                    { 10L, null, null, null, null, null, "/Images/Meatsmith.png", "Meatsmith", null, null },
                    { 16L, null, null, null, null, null, "/Images/SMAT.png", "SMAT", null, null },
                    { 9L, null, null, null, null, null, "/Images/Maia.png", "Maia", null, null },
                    { 7L, null, null, null, null, null, "/Images/Karaki.png", "Karaki", null, null },
                    { 6L, null, null, null, null, null, "/Images/Jwala.png", "Jwala", null, null },
                    { 5L, null, null, null, null, null, "/Images/Gahwetna.png", "Gahwetna", null, null },
                    { 4L, null, null, null, null, null, "/Images/Debs w Remman.png", "Debs w Remman", null, null },
                    { 3L, null, null, null, null, null, "/Images/Build It Burger.png", "Build It Burger", null, null },
                    { 2L, null, null, null, null, null, "/Images/Basta.png", "Basta", null, null },
                    { 8L, null, null, null, null, null, "/Images/La Casa.png", "La Casa", null, null },
                    { 17L, null, null, null, null, null, "/Images/USTA.png", "USTA", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_OutletId",
                table: "Playlists",
                column: "OutletId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_PlaylistId",
                table: "Tracks",
                column: "PlaylistId",
                unique: true);
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
