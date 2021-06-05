using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TuristickaAgencija.Migrations
{
    public partial class AranzmanVodic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vodic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    BrojTelefona = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vodic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aranzman",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumPocetka = table.Column<DateTime>(nullable: false),
                    DatumKraja = table.Column<DateTime>(nullable: false),
                    VodicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aranzman", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aranzman_Vodic_VodicId",
                        column: x => x.VodicId,
                        principalTable: "Vodic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DestinacijaAranzman",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AranzmanId = table.Column<int>(nullable: false),
                    DestinacijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinacijaAranzman", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DestinacijaAranzman_Aranzman_AranzmanId",
                        column: x => x.AranzmanId,
                        principalTable: "Aranzman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestinacijaAranzman_Destinacije_DestinacijaId",
                        column: x => x.DestinacijaId,
                        principalTable: "Destinacije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aranzman_VodicId",
                table: "Aranzman",
                column: "VodicId");

            migrationBuilder.CreateIndex(
                name: "IX_DestinacijaAranzman_AranzmanId",
                table: "DestinacijaAranzman",
                column: "AranzmanId");

            migrationBuilder.CreateIndex(
                name: "IX_DestinacijaAranzman_DestinacijaId",
                table: "DestinacijaAranzman",
                column: "DestinacijaId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestinacijaAranzman");

            migrationBuilder.DropTable(
                name: "Aranzman");

            migrationBuilder.DropTable(
                name: "Vodic");

        }
    }
}
