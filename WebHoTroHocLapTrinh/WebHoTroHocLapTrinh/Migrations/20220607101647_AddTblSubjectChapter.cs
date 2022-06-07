using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHoTroHocLapTrinh.Migrations
{
    public partial class AddTblSubjectChapter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdChapter",
                table: "Exercise",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    IdSubject = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameSubject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.IdSubject);
                });

            migrationBuilder.CreateTable(
                name: "Chapter",
                columns: table => new
                {
                    IdChapter = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameChapter = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdSubject = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapter", x => x.IdChapter);
                    table.ForeignKey(
                        name: "FK_Chapter_Subject_IdSubject",
                        column: x => x.IdSubject,
                        principalTable: "Subject",
                        principalColumn: "IdSubject",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_IdChapter",
                table: "Exercise",
                column: "IdChapter");

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_IdSubject",
                table: "Chapter",
                column: "IdSubject");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Chapter_IdChapter",
                table: "Exercise",
                column: "IdChapter",
                principalTable: "Chapter",
                principalColumn: "IdChapter",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Chapter_IdChapter",
                table: "Exercise");

            migrationBuilder.DropTable(
                name: "Chapter");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_IdChapter",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "IdChapter",
                table: "Exercise");
        }
    }
}
