using Microsoft.EntityFrameworkCore.Migrations;

namespace Wimbee_Hiring.Persistence.Migrations
{
    public partial class addCandidature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidature",
                columns: table => new
                {
                    IdCandidature = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrenomCandidat = table.Column<string>(nullable: false),
                    NomCandidat = table.Column<string>(nullable: false),
                    EtatCandidat = table.Column<string>(nullable: false),
                    CV = table.Column<string>(nullable: false),
                    IdTicket = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidature", x => x.IdCandidature);
                    table.ForeignKey(
                        name: "FK_Candidature_Ticket_IdTicket",
                        column: x => x.IdTicket,
                        principalTable: "Ticket",
                        principalColumn: "IdTicket",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidature_IdTicket",
                table: "Candidature",
                column: "IdTicket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidature");
        }
    }
}
