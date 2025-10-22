using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentTrackerApp.Migrations
{
    /// <inheritdoc />
    public partial class CreationUserField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentDb");

            migrationBuilder.DropTable(
                name: "TeacherDb");

            migrationBuilder.CreateTable(
                name: "UserDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    UserType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDb", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "StudentTeacherDb",
                keyColumn: "Id",
                keyValue: 1,
                column: "TeacherId",
                value: 2);

            migrationBuilder.InsertData(
                table: "UserDb",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "UserType" },
                values: new object[,]
                {
                    { 1, "bobbyhill@etsu.edu", "Bobby", "Hill", "Password", "Student" },
                    { 2, "johnteach@etsu.edu", "John", "Teach", "Password", "Teacher" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDb");

            migrationBuilder.CreateTable(
                name: "StudentDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherDb", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "StudentDb",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 1, "bobbyhill@etsu.edu", "Bobby", "Hill", "Password" });

            migrationBuilder.UpdateData(
                table: "StudentTeacherDb",
                keyColumn: "Id",
                keyValue: 1,
                column: "TeacherId",
                value: 1);

            migrationBuilder.InsertData(
                table: "TeacherDb",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 1, "johnteach@etsu.edu", "John", "Teach", "Password" });
        }
    }
}
