using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTuitionClassFromStudentCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_TuitionClasses_TuitionClassId",
                table: "StudentCourses");

            migrationBuilder.AlterColumn<int>(
                name: "TuitionClassId",
                table: "StudentCourses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "TuitionClassId",
                table: "StudentCourses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_TuitionClasses_TuitionClassId",
                table: "StudentCourses",
                column: "TuitionClassId",
                principalTable: "TuitionClasses",
                principalColumn: "TuitionClassId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
