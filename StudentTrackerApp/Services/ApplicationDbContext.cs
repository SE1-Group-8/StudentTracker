namespace StudentTrackerApp.Services
{
	using Models;
	using Microsoft.EntityFrameworkCore;

	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<Student> StudentTracker { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Student>().HasData(
                new Models.Student { Id = 1, FirstName = "Bobby", LastName = "Hill", Email = "bobbyhill@etsu.edu", Password = "Password", Teacher = "Hank Hill" }
            );
        }
    }
}
