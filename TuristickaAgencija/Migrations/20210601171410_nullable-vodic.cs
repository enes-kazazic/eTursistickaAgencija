using Microsoft.EntityFrameworkCore.Migrations;

namespace TuristickaAgencija.Migrations
{
    public partial class nullablevodic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aranzman_Vodic_VodicId",
                table: "Aranzman");

            migrationBuilder.AlterColumn<int>(
                name: "VodicId",
                table: "Aranzman",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Aranzman_Vodic_VodicId",
                table: "Aranzman",
                column: "VodicId",
                principalTable: "Vodic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aranzman_Vodic_VodicId",
                table: "Aranzman");

            migrationBuilder.AlterColumn<int>(
                name: "VodicId",
                table: "Aranzman",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Aranzman_Vodic_VodicId",
                table: "Aranzman",
                column: "VodicId",
                principalTable: "Vodic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
