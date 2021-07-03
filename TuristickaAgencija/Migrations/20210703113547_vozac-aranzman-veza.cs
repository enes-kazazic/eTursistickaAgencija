using Microsoft.EntityFrameworkCore.Migrations;

namespace TuristickaAgencija.Migrations
{
    public partial class vozacaranzmanveza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VozacId",
                table: "Aranzman",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aranzman_VozacId",
                table: "Aranzman",
                column: "VozacId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aranzman_Vodic_VozacId",
                table: "Aranzman",
                column: "VozacId",
                principalTable: "Vodic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aranzman_Vodic_VozacId",
                table: "Aranzman");

            migrationBuilder.DropIndex(
                name: "IX_Aranzman_VozacId",
                table: "Aranzman");

            migrationBuilder.DropColumn(
                name: "VozacId",
                table: "Aranzman");
        }
    }
}
