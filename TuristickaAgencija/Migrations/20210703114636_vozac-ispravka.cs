using Microsoft.EntityFrameworkCore.Migrations;

namespace TuristickaAgencija.Migrations
{
    public partial class vozacispravka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aranzman_Vodic_VozacId",
                table: "Aranzman");

            migrationBuilder.AddForeignKey(
                name: "FK_Aranzman_Vozac_VozacId",
                table: "Aranzman",
                column: "VozacId",
                principalTable: "Vozac",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aranzman_Vozac_VozacId",
                table: "Aranzman");

            migrationBuilder.AddForeignKey(
                name: "FK_Aranzman_Vodic_VozacId",
                table: "Aranzman",
                column: "VozacId",
                principalTable: "Vodic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
