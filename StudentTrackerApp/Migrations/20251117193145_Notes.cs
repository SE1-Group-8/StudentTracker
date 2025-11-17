using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentTrackerApp.Migrations
{
    /// <inheritdoc />
    public partial class Notes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "CheckInLogDb",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "StudentTeacherDb",
                columns: new[] { "Id", "StudentId", "TeacherId" },
                values: new object[] { 2, 3, 2 });

            migrationBuilder.InsertData(
                table: "UserDb",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "UserType" },
                values: new object[] { 3, "gribble@etsu.edu", "Joseph", "Gribble", "Password", "Student" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentTeacherDb",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserDb",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "CheckInLogDb");
        }
    }
}
