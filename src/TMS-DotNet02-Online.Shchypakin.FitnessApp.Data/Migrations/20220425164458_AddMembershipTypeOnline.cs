using Microsoft.EntityFrameworkCore.Migrations;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Migrations
{
    public partial class AddMembershipTypeOnline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Online",
                schema: "membership",
                table: "MembershipTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Online",
                schema: "membership",
                table: "MembershipTypes");
        }
    }
}
