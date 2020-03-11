using Microsoft.EntityFrameworkCore.Migrations;

namespace Wimbee_Hiring.Persistence.Migrations
{
    public partial class GenericRepository1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tickets",
                table: "Person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tickets",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
