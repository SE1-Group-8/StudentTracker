using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentTrackerApp.Migrations
{
    /// <inheritdoc />
    public partial class StudentTeacherDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentTracker",
                table: "StudentTracker");

            migrationBuilder.RenameTable(
                name: "StudentTracker",
                newName: "StudentDb");

            migrationBuilder.AlterColumn<int>(
                name: "Teacher",
                table: "StudentDb",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentDb",
                table: "StudentDb",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StudentTeacherDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTeacherDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Student = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherDb", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "StudentDb",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Teacher" },
                values: new object[] { 1, "bobbyhill@etsu.edu", "Bobby", "Hill", "Password", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentTeacherDb");

            migrationBuilder.DropTable(
                name: "TeacherDb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentDb",
                table: "StudentDb");

            migrationBuilder.DeleteData(
                table: "StudentDb",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "StudentDb",
                newName: "StudentTracker");

            migrationBuilder.AlterColumn<string>(
                name: "Teacher",
                table: "StudentTracker",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentTracker",
                table: "StudentTracker",
                column: "Id");
        }
    }
}
