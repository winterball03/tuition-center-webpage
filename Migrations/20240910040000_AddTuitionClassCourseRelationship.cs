using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class AddTuitionClassCourseRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "TuitionClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TuitionClasses_CourseId",
                table: "TuitionClasses",
                column: "CourseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TuitionClasses_Courses_CourseId",
                table: "TuitionClasses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TuitionClasses_Courses_CourseId",
                table: "TuitionClasses");

            migrationBuilder.DropIndex(
                name: "IX_TuitionClasses_CourseId",
                table: "TuitionClasses");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "TuitionClasses");
        }
    }
}
