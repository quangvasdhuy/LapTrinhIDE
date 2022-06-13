using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHoTroHocLapTrinh.Migrations
{
    public partial class update_ex1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Input",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Output",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "ApiRapid",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Input",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Output",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApiRapid",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Input",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Output",
                table: "Exercise");

            migrationBuilder.AddColumn<string>(
                name: "Input",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Output",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
