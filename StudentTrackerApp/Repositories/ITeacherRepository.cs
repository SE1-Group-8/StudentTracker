using StudentTrackerApp.Models;

namespace StudentTrackerApp.Repositories
{
    public interface ITeacherRepository
    {
        Task<ICollection<Teacher>> ReadAllAsync();
        Task<Teacher> CreateAsync(Teacher newTeacher);
        Task<Teacher?> ReadAsync(int id);
        Task UpdateAsync(int oldId, Teacher person);
        Task DeleteAsync(int id);
    }
}
