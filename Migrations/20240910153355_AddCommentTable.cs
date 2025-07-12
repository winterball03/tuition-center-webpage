using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourse_Courses_CourseId",
                table: "TeacherCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourse_Users_TeacherId",
                table: "TeacherCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherCourse",
                table: "TeacherCourse");

            migrationBuilder.RenameTable(
                name: "TeacherCourse",
                newName: "TeacherCourses");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherCourse_TeacherId",
                table: "TeacherCourses",
                newName: "IX_TeacherCourses_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherCourse_CourseId",
                table: "TeacherCourses",
                newName: "IX_TeacherCourses_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherCourses",
                table: "TeacherCourses",
                column: "TeacherCourseId");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuitionClassId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_TuitionClasses_TuitionClassId",
                        column: x => x.TuitionClassId,
                        principalTable: "TuitionClasses",
                        principalColumn: "TuitionClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TuitionClassId",
                table: "Comments",
                column: "TuitionClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourses_Courses_CourseId",
                table: "TeacherCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourses_Users_TeacherId",
                table: "TeacherCourses",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourses_Courses_CourseId",
                table: "TeacherCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourses_Users_TeacherId",
                table: "TeacherCourses");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherCourses",
                table: "TeacherCourses");

            migrationBuilder.RenameTable(
                name: "TeacherCourses",
                newName: "TeacherCourse");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherCourses_TeacherId",
                table: "TeacherCourse",
                newName: "IX_TeacherCourse_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherCourses_CourseId",
                table: "TeacherCourse",
                newName: "IX_TeacherCourse_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherCourse",
                table: "TeacherCourse",
                column: "TeacherCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourse_Courses_CourseId",
                table: "TeacherCourse",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourse_Users_TeacherId",
                table: "TeacherCourse",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
