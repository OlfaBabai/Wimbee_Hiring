using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wimbee_Hiring.Persistence.Migrations
{
    public partial class nvTicketAttributs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Ticket");

            migrationBuilder.AddColumn<string>(
                name: "Budgetisation",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Certification",
                table: "Ticket",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChargeInterOpportunite",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChargeInterProjet",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompetenceFonctionnelle",
                table: "Ticket",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompetenceTechnique",
                table: "Ticket",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Confirmation",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDebutPlutard",
                table: "Ticket",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDebutSouhaite",
                table: "Ticket",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Departement",
                table: "Ticket",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DureeInterOpportunite",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DureeInterProjet",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Importance",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LieuInterOpportunite",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LieuInterProjet",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Motif",
                table: "Ticket",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameClient",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOpportunite",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameProjet",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomProspect",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "NombreAnnee",
                table: "Ticket",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Optionnel",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PackFinancierAnnuel",
                table: "Ticket",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Poste",
                table: "Ticket",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Probabilite",
                table: "Ticket",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<double>(
                name: "SalaireBud",
                table: "Ticket",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "SoftSkills",
                table: "Ticket",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StateTraitement",
                table: "Ticket",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StateValidation",
                table: "Ticket",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Urgence",
                table: "Ticket",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Budgetisation",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Certification",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "ChargeInterOpportunite",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "ChargeInterProjet",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "CompetenceFonctionnelle",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "CompetenceTechnique",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Confirmation",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "DateDebutPlutard",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "DateDebutSouhaite",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Departement",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "DureeInterOpportunite",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "DureeInterProjet",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Importance",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "LieuInterOpportunite",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "LieuInterProjet",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Motif",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "NameClient",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "NameOpportunite",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "NameProjet",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "NomProspect",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "NombreAnnee",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Optionnel",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "PackFinancierAnnuel",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Poste",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Probabilite",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "SalaireBud",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "SoftSkills",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "StateTraitement",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "StateValidation",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Urgence",
                table: "Ticket");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
