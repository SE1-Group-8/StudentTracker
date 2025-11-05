using Microsoft.EntityFrameworkCore;
using StudentTrackerApp.Models;
using StudentTrackerApp.Services;

namespace StudentTrackerApp.Repositories
{
    public class DbCheckInRepository
    {
        private readonly ApplicationDbContext _db;

        public DbCheckInRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<CheckInLog> CreateCheckInAsync(CheckInLog log)
        {
            await _db.CheckInLogDb.AddAsync(log);
            await _db.SaveChangesAsync();
            return log;
        }

        public async Task<CheckInLog?> GetActiveCheckInAsync(int userId)
        {
            return await _db.CheckInLogDb
                .Where(l => l.UserId == userId && l.CheckOutTime == null)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateCheckOutAsync(CheckInLog log)
        {
            _db.CheckInLogDb.Update(log);
            await _db.SaveChangesAsync();
        }
    }
}
