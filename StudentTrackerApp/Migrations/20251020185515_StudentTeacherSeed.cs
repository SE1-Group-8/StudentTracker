using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentTrackerApp.Migrations
{
    /// <inheritdoc />
    public partial class StudentTeacherSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StudentTeacherDb",
                columns: new[] { "Id", "StudentId", "TeacherId" },
                values: new object[] { 1, 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentTeacherDb",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
