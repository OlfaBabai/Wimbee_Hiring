using Microsoft.EntityFrameworkCore.Migrations;

namespace Wimbee_Hiring.Persistence.Migrations
{
    public partial class emailandpasswordUpdatedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password1",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Person",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "Password1",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
