using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TuristickaAgencija.Migrations
{
    public partial class DestinacijaAranzmanDatum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatumKraja",
                table: "DestinacijaAranzman",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumPocetka",
                table: "DestinacijaAranzman",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatumKraja",
                table: "DestinacijaAranzman");

            migrationBuilder.DropColumn(
                name: "DatumPocetka",
                table: "DestinacijaAranzman");
        }
    }
}
