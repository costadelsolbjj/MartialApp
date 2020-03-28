using Microsoft.EntityFrameworkCore.Migrations;

namespace MartialApp.Migrations
{
    public partial class MartialAppDBremoveEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Trainers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Trainers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
