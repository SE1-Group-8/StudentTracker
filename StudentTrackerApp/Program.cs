using Microsoft.EntityFrameworkCore;
using StudentTrackerApp.Components;
using StudentTrackerApp.Repositories;
using StudentTrackerApp.Repositories.OldStuff;
using StudentTrackerApp.Services;

namespace StudentTrackerApp
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

			builder.Services.AddDbContext<ApplicationDbContext>(options =>
	            options.UseSqlite("Data Source=Data/StudentTracker.db"));

            builder.Services.AddScoped<IUserRepository, DbUserRepository>();
            builder.Services.AddScoped<IStudentTeacherRepository, DbStudentTeacherRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
