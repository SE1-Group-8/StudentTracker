namespace StudentTrackerApp.Services
{
	using Models;
	using Microsoft.EntityFrameworkCore;

	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<User> UserDb { get; set; }
        public DbSet<StudentTeacher> StudentTeacherDb { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.User>().HasData(
                new Models.User { Id = 1, FirstName = "Bobby", LastName = "Hill", Email = "bobbyhill@etsu.edu", Password = "Password", UserType = "Student" }
            );
			modelBuilder.Entity<Models.User>().HasData(
				new Models.User { Id = 2, FirstName = "John", LastName = "Teach", Email = "johnteach@etsu.edu", Password = "Password", UserType="Teacher" }
			);
			modelBuilder.Entity<Models.StudentTeacher>().HasData(
				new Models.StudentTeacher { Id = 1, StudentId = 1, TeacherId = 2 }
			);
		}
    }
}
