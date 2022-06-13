using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHoTroHocLapTrinh.Migrations
{
    public partial class update_ex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Input",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Output",
                table: "User");
        }
    }
}
