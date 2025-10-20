namespace StudentTrackerApp.Services
{
	using Models;
	using Microsoft.EntityFrameworkCore;

	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<Student> StudentDb { get; set; }
        public DbSet<Teacher> TeacherDb { get; set; }
        public DbSet<StudentTeacher> StudentTeacherDb { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Student>().HasData(
                new Models.Student { Id = 1, FirstName = "Bobby", LastName = "Hill", Email = "bobbyhill@etsu.edu", Password = "Password" }
            );
			modelBuilder.Entity<Models.Teacher>().HasData(
				new Models.Teacher { Id = 1, FirstName = "John", LastName = "Teach", Email = "johnteach@etsu.edu", Password = "Password" }
			);
			modelBuilder.Entity<Models.StudentTeacher>().HasData(
				new Models.StudentTeacher { Id = 1, StudentId = 1, TeacherId = 1 }
			);
		}
    }
}
