using Microsoft.EntityFrameworkCore.Migrations;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Migrations
{
    public partial class AddVideoName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Videolinks",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Videolinks");
        }
    }
}
