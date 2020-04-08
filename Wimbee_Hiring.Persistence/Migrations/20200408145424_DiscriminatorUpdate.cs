using Microsoft.EntityFrameworkCore.Migrations;

namespace Wimbee_Hiring.Persistence.Migrations
{
    public partial class DiscriminatorUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Person",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
