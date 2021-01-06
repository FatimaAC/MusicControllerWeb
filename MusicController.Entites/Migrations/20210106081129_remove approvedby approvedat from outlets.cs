using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicController.Entites.Migrations
{
    public partial class removeapprovedbyapprovedatfromoutlets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedAt",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "ApprovedAt",
                table: "Outlets");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Outlets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedAt",
                table: "Playlists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "Playlists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedAt",
                table: "Outlets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "Outlets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
