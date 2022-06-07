using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHoTroHocLapTrinh.Migrations
{
    public partial class AddUserSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfBirth = table.Column<int>(type: "int", nullable: false),
                    YearOfStudent = table.Column<int>(type: "int", nullable: false),
                    IsTeacher = table.Column<bool>(type: "bit", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseDetail",
                columns: table => new
                {
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdExercise = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPass = table.Column<bool>(type: "bit", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseDetail", x => new { x.IdUser, x.IdExercise });
                    table.ForeignKey(
                        name: "FK_ExerciseDetail_Exercise",
                        column: x => x.IdExercise,
                        principalTable: "Exercise",
                        principalColumn: "IdExercise",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseDetail_User",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseDetail_IdExercise",
                table: "ExerciseDetail",
                column: "IdExercise");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseDetail");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
