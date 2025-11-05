using StudentTrackerApp.Models;

namespace StudentTrackerApp.Repositories
{
    public interface ICheckInRepository
    {
        Task<CheckInLog> CreateCheckInAsync(CheckInLog log);
        Task<CheckInLog?> GetActiveCheckInAsync(int userId);
        Task UpdateCheckOutAsync(CheckInLog log);
        Task<List<CheckInLog>> GetLogsByUserIdAsync(int userId);
    }
}
