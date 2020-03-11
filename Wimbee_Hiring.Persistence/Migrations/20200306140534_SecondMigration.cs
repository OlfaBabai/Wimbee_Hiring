using Microsoft.EntityFrameworkCore.Migrations;

namespace Wimbee_Hiring.Persistence.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdWriter",
                table: "Ticket",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Tickets",
                table: "Person",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_IdWriter",
                table: "Ticket",
                column: "IdWriter");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Person_IdWriter",
                table: "Ticket",
                column: "IdWriter",
                principalTable: "Person",
                principalColumn: "IdPerson",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Person_IdWriter",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_IdWriter",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "IdWriter",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Tickets",
                table: "Person");
        }
    }
}
