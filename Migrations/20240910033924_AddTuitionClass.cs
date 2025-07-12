using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class AddTuitionClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TuitionClassId",
                table: "StudentCourses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TuitionClasses",
                columns: table => new
                {
                    TuitionClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teacher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuitionClasses", x => x.TuitionClassId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_TuitionClassId",
                table: "StudentCourses",
                column: "TuitionClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_TuitionClasses_TuitionClassId",
                table: "StudentCourses",
                column: "TuitionClassId",
                principalTable: "TuitionClasses",
                principalColumn: "TuitionClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_TuitionClasses_TuitionClassId",
                table: "StudentCourses");

            migrationBuilder.DropTable(
                name: "TuitionClasses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_TuitionClassId",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "TuitionClassId",
                table: "StudentCourses");
        }
    }
}
