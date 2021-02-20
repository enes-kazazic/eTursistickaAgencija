using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TuristickaAgencija.Migrations
{
    public partial class TuristickaAgencija5Tabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(nullable: false),
                    Cijena = table.Column<double>(nullable: false),
                    BrojRacuna = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Placanje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iznos = table.Column<double>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    NacinPlacanja = table.Column<string>(nullable: true),
                    RezervacijaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placanje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Placanje_Rezervacija_RezervacijaId",
                        column: x => x.RezervacijaId,
                        principalTable: "Rezervacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "OdabirSmjestaja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrstaSobe = table.Column<string>(nullable: true),
                    BrojSobe = table.Column<int>(nullable: false),
                    SmjestajId = table.Column<int>(nullable: true),
                    RezervacijaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdabirSmjestaja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OdabirSmjestaja_Rezervacija_RezervacijaId",
                        column: x => x.RezervacijaId,
                        principalTable: "Rezervacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OdabirSmjestaja_Smjestaji_SmjestajId",
                        column: x => x.SmjestajId,
                        principalTable: "Smjestaji",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            
            migrationBuilder.CreateIndex(
                name: "IX_OdabirSmjestaja_RezervacijaId",
                table: "OdabirSmjestaja",
                column: "RezervacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_OdabirSmjestaja_SmjestajId",
                table: "OdabirSmjestaja",
                column: "SmjestajId");

            migrationBuilder.CreateIndex(
                name: "IX_Placanje_RezervacijaId",
                table: "Placanje",
                column: "RezervacijaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OdabirSmjestaja");

            migrationBuilder.DropTable(
                name: "Placanje");

            migrationBuilder.DropTable(
                name: "Rezervacija");
        }
    }
}
