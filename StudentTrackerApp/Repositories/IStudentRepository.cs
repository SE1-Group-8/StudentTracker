using StudentTrackerApp.Models;
using System;

namespace StudentTrackerApp.Repositories
{
    public interface IStudentRepository
    {
        Task<ICollection<Student>> ReadAllAsync();
        Task<Student> CreateAsync(Student newStudent);
        Task<Student?> ReadAsync(int id);
        Task UpdateAsync(int oldId, Student person);
        Task DeleteAsync(int id);
    }
}
