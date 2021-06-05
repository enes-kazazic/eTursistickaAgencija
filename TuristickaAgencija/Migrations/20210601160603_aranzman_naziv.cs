using Microsoft.EntityFrameworkCore.Migrations;

namespace TuristickaAgencija.Migrations
{
    public partial class aranzman_naziv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "Aranzman",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "Aranzman");
        }
    }
}
